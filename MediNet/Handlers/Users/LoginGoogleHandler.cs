using Google.Apis.Auth;
using MediatR;
using MediNet.DTOs;
using MediNet.Models;
using MediNet.Repositories.IRepositories;
using MediNet.Services.IServices;
using System.Security.Claims;
using MediNet.Commands.Users;
using System.Text.RegularExpressions;
using MediNet.Models.Enums;

namespace MediNet.Handlers.Users
{
    public class LoginGoogleHandler : IRequestHandler<LoginGoogleCommand, AuthResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public LoginGoogleHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDTO> Handle(LoginGoogleCommand command, CancellationToken cancellationToken)
        {
            var payload = GoogleJsonWebSignature.ValidateAsync(command.TokenId, new GoogleJsonWebSignature.ValidationSettings()).Result;

            var email = payload.Email;

            var fpt = new Regex("[a-z0-9]+@fpt.edu.vn");
            var fe = new Regex("[a-z0-9]+@fe.edu.vn");

            if (!fpt.IsMatch(email) && !fe.IsMatch(email))
            {
                throw new ApplicationException("Email must be end @fpt.edu.vn or @fe.edu.vn");
            }

            var user = await _unitOfWork.UserRepository.FindUser(payload);
            if (user == null)
            {
                user = new User()
                {
                    Email = payload.Email,
                    Image = payload.Picture,
                    IsDeleted = false,
                };
                await _unitOfWork.Repository<User>().AddAsync(user);
                await _unitOfWork.Save(cancellationToken);
            }

            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("Role", Enum.GetName(typeof(Role),user.Role))
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
