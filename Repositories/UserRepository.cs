﻿using Coding_Test.Dtos;
using Coding_Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Coding_Test.Entities;
using Coding_Test.Interfaces;
using Coding_Test.Dtos;

namespace Coding_Test.Repositories
{
    public enum RepoResult
    {
        Success, Failure, NotExist
    }
    public class UserRepository : IUserRepository
    {
        private readonly CodingTestContext _context;
        private readonly IMapper _mapper;
        public UserRepository(CodingTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(RegisterDto dto)
        {
            try
            {
                var newUser = _mapper.Map<User>(dto);
                newUser.Password = HelperMethods.HashPassword(dto.Password);
                await  _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            catch
            {
                return null;
            }


        }

        public RepoResult SignIn(UserLoginDto dto)
        {
            var userInDb = _context.Users.Where(x => x.Email == dto.Email);
            if (userInDb.Count() != 1) return RepoResult.NotExist;
           

           var userPasswordHash = HelperMethods.HashPassword(dto.Password);
           if (userPasswordHash != userInDb.Single().Password) return RepoResult.Failure;

            return RepoResult.Success;

        }

        public List<UsersListDto> GetAll()
        {
            var users=_context.Users.Take(10).Select(x=> new UsersListDto {
                Name=x.Name,
                Email=x.Email,
                RegistrationDate= x.CreatedAt.ToString("d")
            }).AsQueryable().ToList();

            return users;
        }
    }
}