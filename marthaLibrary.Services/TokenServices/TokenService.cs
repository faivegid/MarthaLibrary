using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Models.Config;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace marthaLibrary.Services.TokenServices
{
    public class TokenService : ITokenService
    {
        private readonly JwtSetting _jwtSettings;

        public TokenService(
            JwtSetting jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(AppUser user)
        {
            List<Claim> authClaims = GetClaims(user);
            var sigingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            JwtSecurityToken token = CreateToken(authClaims, sigingKey);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(ResetCode code, AppUser user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Authentication, code.Id.ToString())
            };
            var sigingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            JwtSecurityToken token = CreateToken(authClaims, sigingKey, 5);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #region Private Methods
        private JwtSecurityToken CreateToken(List<Claim> authClaims, SymmetricSecurityKey sigingKey, int duration = 0)
        {
            return new JwtSecurityToken(
                audience: _jwtSettings.Audience,
                issuer: _jwtSettings.Issuer,
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(duration == 0 ? _jwtSettings.Duration : duration),
                signingCredentials: new SigningCredentials(sigingKey, SecurityAlgorithms.HmacSha256)
            );
        }

        private List<Claim> GetClaims(AppUser user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            return authClaims;
        }
        #endregion
    }
}
