using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Identity
{
    public static class TokenGenerator
    {
        public static string GenerateToken(UserEntity user)
        {
            SigningCredentials credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")),
                SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("Id",user.Id.ToString()),
                new Claim("Username",user.Username)
                new Claim("Alarms",JsonSerializer.Serialize(user.Alarms))
            };

            var securityToken = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(10),
                claims: claims,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
