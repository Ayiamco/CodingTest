using Coding_Test.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole():base()
        {
                
        }
        public ApplicationRole(string rolename):base(rolename)
        {

        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    //public class ApplicationUserManager : UserManager<ApplicationUser>
    //{
    //    public ApplicationUserManager(IUserStore<ApplicationUser> store)
    //        : base(store)
    //    {
    //    }
    //}

    //public class ApplicationSignInManager : SignInManager<ApplicationUser>
    //{
    //    public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }


    //}

}
