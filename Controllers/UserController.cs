using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coding_Test.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Coding_Test.Dtos;
using Coding_Test.Entities;

namespace Coding_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("all")]
        public ActionResult GetAllUsers()
        {
            var users = _repo.GetAll();
            return StatusCode(200,new ResponseDto<IEnumerable<UsersListDto>> { data=users,status=200 }) ;
        }


    }
}
