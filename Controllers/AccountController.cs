using Coding_Test.Dtos;
using Coding_Test.Interfaces;
using Coding_Test.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private IConfiguration _configManager;
        public AccountController(IUserRepository repo,IJwtAuthenticationManager jwtManager,IConfiguration configuration)
        {
            _repo = repo;
            _jwtMananager = jwtManager;
            _configManager = configuration;
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
                if (result == RepoResult.Success)
                {
                    var newRefreshToken = _repo.ResetRefreshToken(model.Email);
                    return StatusCode(200, new ResponseDto<LoginResponse>()
                    {
                        message = "sign in successful",
                        status = 200,
                        data = new LoginResponse
                        {
                            RefreshToken=newRefreshToken,
                            Token = _jwtMananager.GetToken(model.Email)
                        }
                    });

                }

                if(result == RepoResult.NotExist)   return BadRequest(new ResponseDto<string>() { status = 400, message = "{\"email\":\"email does not exist\"}" });

                return BadRequest(new ResponseDto<string>() { status = 400, message = "{\"password\":\"password is incorrect\"}" });
            }
            catch(Exception e)
            {
                return StatusCode(500, new ResponseDto<string>() { status = 500, message = "{\"summary\":\"internal server error\"}" });

            }
        }

        [HttpPost("refreshToken")]
        public ActionResult RefreshToken([FromBody] LoginResponse token)
        {
            try
            {
                var claim = _jwtMananager.GetPrincipalFromExpiredToken(token.Token, _configManager["CondingTestTokenKey:jwtKey"]);
                var refreshToken = _repo.GetRefreshToken(claim.Identity.Name);
                var newJwt = _jwtMananager.RefreshJwt(claim.Identity.Name, token.RefreshToken, refreshToken);
                var newRefreshToken = _repo.ResetRefreshToken(claim.Identity.Name);

                return StatusCode(200, new ResponseDto<LoginResponse>
                {
                    status = 200,
                    message = "code refresh successfull",
                    data = new LoginResponse{
                                RefreshToken=newRefreshToken,
                                Token= newJwt
                           }
                });
            }
            catch(SecurityTokenException)
            {
                return StatusCode(400, new ResponseDto<string> { status = 400, message = "invalid refresh token" });
            }
            catch
            {
                return StatusCode(500, new ResponseDto<string> { status = 500, message = "internal server error" });
            }
            


        }
    }
}
