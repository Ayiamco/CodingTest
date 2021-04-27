using Coding_Test.Dtos;
using Coding_Test.Interfaces;
using Coding_Test.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository _repo;
        private IJwtAuthenticationManager _jwtMananager;
        public AccountController(IUserRepository repo,IJwtAuthenticationManager jwtManager)
        {
            _repo = repo;
            _jwtMananager = jwtManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content("This is testing");
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _repo.CreateAsync(user);
                if (result != null) 
                return StatusCode(201,
                    new ResponseDto<string>() { message="user created successfully", status = 201 });

                return BadRequest(new ResponseDto<string>() { status = 400, message = "user already exist" });
            }
            catch
            {
                return StatusCode(500, new ResponseDto<string>() { status = 500, message = "internal server error" });

            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseDto<string>() { message = "{\"email\":\"form data failed validation\"}", status = 400 });

            try
            {
                var result = _repo.SignIn(model);
                if (result == RepoResult.Success) return StatusCode(200,  new ResponseDto<LoginResponse>() { 
                    message = "sign in successful",
                    status = 200,
                    data= new LoginResponse
                    {
                        Token= _jwtMananager.GetToken(model)
                    }

                });

                if(result == RepoResult.NotExist)   return BadRequest(new ResponseDto<string>() { status = 400, message = "{\"email\":\"email does not exist\"}" });

                return BadRequest(new ResponseDto<string>() { status = 400, message = "{\"password\":\"password is incorrect\"}" });
            }
            catch(Exception e)
            {
                return StatusCode(500, new ResponseDto<string>() { status = 500, message = "{\"summary\":\"internal server error\"}" });

            }
        }
    }
}
