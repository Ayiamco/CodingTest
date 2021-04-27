using Coding_Test.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Coding_Test.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        public string GetToken(string _userEmail);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string key);
        public string RefreshJwt(string userEmail, string refreshToken, string savedRefreshToken);
    }
}
