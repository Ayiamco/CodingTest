using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Coding_Test.Interfaces;
using Coding_Test.Dtos;

namespace Coding_Test.Infrastructure
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private string encryptionKey;
        public JwtAuthenticationManager(string encryptionKey)
        {
            this.encryptionKey = encryptionKey;
        }

        public string GetToken(UserLoginDto _user)
        {
            //create security token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(encryptionKey);

            //create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, _user.Email),
                        
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


    }
}
