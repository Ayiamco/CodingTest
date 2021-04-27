using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }
    
}
