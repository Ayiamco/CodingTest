using Coding_Test.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Infrastructure
{
    public class CodingTestContext:DbContext
    {
        public CodingTestContext(DbContextOptions<CodingTestContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
            builder.Entity<User>().HasData(
                new User { Id=1,CreatedAt= DateTime.Now,UpdatedAt=DateTime.Now,Name= "User 1", Password=HelperMethods.HashPassword("user1"), Email="user1@domain.com"},
                new User { Id=2,CreatedAt= DateTime.Now,UpdatedAt=DateTime.Now,Name= "User 2", Password=HelperMethods.HashPassword("user2"), Email="user2@domain.com"},
                new User { Id=3,CreatedAt= DateTime.Now,UpdatedAt=DateTime.Now,Name= "User 3", Password=HelperMethods.HashPassword("user3"), Email="user3@domain.com"},
                new User { Id=4,CreatedAt= DateTime.Now,UpdatedAt=DateTime.Now,Name= "User 4", Password=HelperMethods.HashPassword("user4"), Email="user4@domain.com"},
                new User { Id=5,CreatedAt= DateTime.Now,UpdatedAt=DateTime.Now,Name= "User 5", Password=HelperMethods.HashPassword("user5"), Email="user5@domain.com"},
                new User { Id=6,CreatedAt= DateTime.Now,UpdatedAt=DateTime.Now,Name= "User 6", Password=HelperMethods.HashPassword("user6"), Email="user6@domain.com"}
                );
        }
    }
}
