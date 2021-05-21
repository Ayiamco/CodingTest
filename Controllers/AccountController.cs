using Coding_Test.Dtos;
using Coding_Test.Infrastructure;
using Coding_Test.Interfaces;
using Coding_Test.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coding_Test.Entities;
using Newtonsoft.Json;

namespace Coding_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IJwtAuthenticationManager _jwtMananager;
        private IUserRepository _repo;
        private IConfiguration _configManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(IJwtAuthenticationManager jwtManager,IUserRepository repo,
            IConfiguration configuration, UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _repo = repo;
            _jwtMananager = jwtManager;
            _configManager = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
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

            //try
            //{
                var result = await _userManager.CreateAsync( new ApplicationUser { UserName=user.Email, Email=user.Email,Name=user.Name},user.Password );
                if (result.Succeeded) 
                return StatusCode(201,
                    new ResponseDto<string>() { message="user created successfully", status = 201 });

            
            return BadRequest(new ResponseDto<string>() { status = 400, message = AddErrors(result.Errors) });
            //}
            //catch
            //{
            //    return StatusCode(500, new ResponseDto<string>() { status = 500, message = "internal server error" });

            //}
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseDto<string>() { message = "{\"email\":\"form data failed validation\"}", status = 400 });

            var result= await _signInManager.PasswordSignInAsync(model.Email, model.Password, false,lockoutOnFailure:false);
            if (result.Succeeded)
            {
                var newRefreshToken = _repo.ResetRefreshToken(model.Email);
                return StatusCode(200, new ResponseDto<AuthResponse>()
                {
                    message = "sign in successful",
                    status = 200,
                    data = new AuthResponse
                    {
                        RefreshToken=newRefreshToken,
                        Token = _jwtMananager.GetToken(model.Email)
                    }
                });

            }

            return BadRequest(new ResponseDto<string>() { status = 400, message = "" });;

            
            //catch
            //{
            //    return StatusCode(500, new ResponseDto<string>() { status = 500, message = "{\"summary\":\"internal server error\"}" });

            //}
        }

        [HttpPost("refreshToken")]
        public ActionResult RefreshToken([FromBody] AuthResponse token)
        {
            try
            {
                var claim = _jwtMananager.GetPrincipalFromExpiredToken(token.Token, _configManager[AppConstants.JwtKey]);
                var refreshToken = _repo.GetRefreshToken(claim.Identity.Name);
                var newJwt = _jwtMananager.RefreshJwt(claim.Identity.Name, token.RefreshToken, refreshToken);
                var newRefreshToken = _repo.ResetRefreshToken(claim.Identity.Name);

                return StatusCode(200, new ResponseDto<AuthResponse>
                {
                    status = 200,
                    message = "code refresh successfull",
                    data = new AuthResponse{
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

        private string AddErrors(IEnumerable<IdentityError> errors)
        {
            var dict = new Dictionary<string, string>();
            foreach(var error in errors)
            {
                dict.Add( error.Code,error.Description);
            }
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            return json;
        }
    }
}
