using Coding_Test.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Infrastructure
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    //builder.Entity<IdentityUser>()
        //    //    .HasIndex(x => x.Email)
        //    //    .IsUnique();

        //    //builder.Entity<IdentityUser>().HasData(
        //    //    new IdentityUser { Email="user1@domain.com"}
        //    //    );
        //}
    } 
}
