using Coding_Test.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Coding_Test.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        public string GetToken(UserLoginDto _user);
    }
}
