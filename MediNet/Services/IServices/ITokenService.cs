using System.Security.Claims;

namespace MediNet.Services.IServices
{
    public interface ITokenService
    {
        string GenerateRefreshToken();
        string GenerateAccessToken(IEnumerable<Claim> claims);
        Task<ClaimsPrincipal?> GetPrincipalFromExpiredToken(string token);
    }
}
