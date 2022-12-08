using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PowerMessenger.Core.Common;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerMessenger.Application.Services
{
    public class JwtToken : IJwtToken
    {
        private readonly IOptions<JWTOptions> _jwtOptions;

        public JwtToken(IOptions<JWTOptions> jwtOptions)
        {
            _jwtOptions= jwtOptions;
        }

        public string GenerateJWT(User user)
        {
            var authParams = _jwtOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Name,user.Name),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims,
                expires: DateTime.Now.AddMinutes(authParams.TokenLifeTime), signingCredentials: credintials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
