using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialContact.Data.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialContact.Core.Security
{
    public class JwtService
    {
        public static string GenerateToken(AppUser appUser, IConfiguration configuration)
        {
            var claim = new List<Claim>() {

                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWTConfigurations:SecretKey").Value));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claim),
                Audience = configuration.GetSection("JWTConfigurations:Audience").Value,
                Issuer = configuration.GetSection("JWTConfigurations:Issuer").Value,
                Expires = DateTime.Now + TimeSpan.Parse(configuration.GetSection("JWTConfigurations:TokenLifeTime").Value),
                SigningCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha256)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var token  = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
