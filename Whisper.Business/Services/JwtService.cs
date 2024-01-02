using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Whisper.Core.Application.Services;
using Whisper.Core.Domain.Entities;

namespace Whisper.Business.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;

        }

        public string GenerateToken(AppUser user)
        {
            List<Claim> claims = GetUserClaims(user);

            SymmetricSecurityKey securityKey = GetSymmetricSecurityKey();

            SigningCredentials credentials = GetSigningCredentials(securityKey);

            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration.GetSection("Jwt:issuer").Value,
                                                          audience: _configuration.GetSection("Jwt:audience").Value,
                                                          claims: claims,
                                                          expires: DateTime.UtcNow.AddDays(1),
                                                          signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> GetUserClaims(AppUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("PublicKey", user.PublicKey)
            };

            IList<string> userRoles = _userManager.GetRolesAsync(user).Result;

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:securityKey").Value));
        }

        private SigningCredentials GetSigningCredentials(SymmetricSecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
