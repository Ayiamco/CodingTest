using Coding_Test.Dtos;
using Coding_Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Coding_Test.Entities;
using Coding_Test.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Coding_Test.Repositories
{
    public enum RepoResult
    {
        Success, Failure, NotExist
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<ApplicationUser> CreateAsync(RegisterDto dto)
        //{
        //    try
        //    {
        //        var newUser = _mapper.Map<ApplicationUser>(dto);
        //        newUser.Password = HelperMethods.HashPassword(dto.Password);
        //        await  _context.Users.AddAsync(newUser);
        //        await _context.SaveChangesAsync();
        //        return newUser;
        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}

        public RepoResult SignIn(UserLoginDto dto)
        {
            var userInDb = _context.Users.Where(x => x.Email == dto.Email).SingleOrDefault();
            var userPasswordHash = HelperMethods.HashPassword(dto.Password);
            if (userInDb== null) return RepoResult.NotExist;
            if (userPasswordHash != "") return RepoResult.Failure;

            return RepoResult.Success;

        }

        public List<UsersListDto> GetAll()
        {
            var users=_context.Users.Take(10).Select(x=> new UsersListDto {
                Name=x.UserName,
                Email=x.Email,
            }).AsQueryable().ToList();

            return users;
        }

        public string GetRefreshToken(string userEmail)
        {
            //return _context.Users.Where(x => x.Email == userEmail).Single().RefreshToken; 
            return "" ;
        }

        public string ResetRefreshToken(string userEmail)
        {
           var user=_context.Users.Where(x => x.Email == userEmail).Single();
           var token= HelperMethods.GetRefreshToken();
            //user.RefreshToken = token;
            _context.SaveChanges();
            return token;
        }
    }
}
