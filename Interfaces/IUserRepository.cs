using Coding_Test.Dtos;
using Coding_Test.Entities;
using Coding_Test.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coding_Test.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(RegisterDto dto);

        RepoResult SignIn(UserLoginDto dto);

        List<UsersListDto> GetAll();
    }
}