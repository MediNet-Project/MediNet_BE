using MediatR;
using MediNet.Commands.Users;
using MediNet.DTOs;
using MediNet.Exceptions;
using MediNet.Models;
using MediNet.Models.Enums;
using MediNet.Repositories.IRepositories;
using MediNet.Services.IServices;
using System.Security.Claims;

namespace MediNet.Handlers.Users
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, AuthResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public LoginUserHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindByEmail(request.Email) ?? throw new NotFoundException("User Not Found.");
            if (user == null)
            {
                throw new ApplicationException("User Not Found");
            }

            var isCheckPwd = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            
            if (isCheckPwd == false)
            {
                throw new ApplicationException("Password is not correct.");
            }
           
            
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role),
                new Claim("UserName", user.UserName),
                new Claim("Image", user.Image == null ? "" : user.Image),
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.Save(cancellationToken);
            
            return new AuthResponseDTO()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
