using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Extensions;

namespace Targi.Infrastructure.Helpers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;
        public JwtHandler(IOptions<JwtSettings> settings)
        {
            _jwtSettings = settings.Value;
        }
        public JwtDto CreateTokem(Guid userId, string role,string name)
        {

            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, name),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.Ticks.ToString()),
            };
            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }

        
    }

    public class JwtSettings
    {   
        public string Key { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
