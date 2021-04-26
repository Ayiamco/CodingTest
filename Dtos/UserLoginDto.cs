using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Dtos
{
    public class UserLoginDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }
    
}
