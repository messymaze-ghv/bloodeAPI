using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BloodeAPI.ViewModels.Request;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.Utilities;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BloodeAPI.ViewModels.Request.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BloodeAPI.ViewModels.Response;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration config;

        public string Issuer { get; }
        public string Audience { get; }
        public string Token { get; }

        private readonly IMapper _mapper;


        public AuthController(IAuthRepository repo,IConfiguration config, IMapper mapper)
        {
            this._repository = repo;
            this._mapper = mapper;
            this.config = config;
            Issuer = this.config.GetSection("AppSettings:Issuer").Value!;
            Audience = this.config.GetSection("AppSettings:Audience").Value!;
            Token = this.config.GetSection("AppSettings:Token").Value!;
        }

        //[HttpPost("Login")]
        //public IActionResult Login([FromBody] LoginRequest request)
        //{
        //    try
        //    {
        //        if (request.UserName != null && request.Password != null)
        //        {
        //            var username = request.UserName;
        //            var password = request.Password.GenerateHashing();
        //            var user = this.dbCtx.Users.Where(ind => (ind.Email == request.UserName || ind.PhoneNumber == request.UserName)).Single();
        //            return Ok(user.Password == HashUtils.GenerateHashing(request.Password));

        //        }
        //        return new BadRequestResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        return (IActionResult)ex;
        //    }
        //}

        //[HttpPost("Register")]
        //public IActionResult Signup([FromBody] SignupRequest request)
        //{
        //    try
        //    {
        //        request.Password = HashUtils.GenerateHashing(request!.Password!);
        //        var dbUser = this._mapper.Map<User>(request);
        //        this.dbCtx.Users.Add(dbUser);
        //        this.dbCtx.SaveChanges();
        //        return Ok(true);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.InnerException.Message);
        //    }
        //}


        // POST: api/auth/register
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest userDto)
            {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }



                // Create the user
                var user = _mapper.Map<User>(userDto);
                var result = await _repository.CreateAsync(user);
                if (result == null)
                {
                    return BadRequest("Username already exists.");
                }
                // Map the user data to a UserDto object and return it in the response body
                var token = JwtTokenHelper.createJwtToken(user, Token, Issuer, Audience);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }


        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginDto)
        {
            // Validate the request body
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Retrieve the user from the database
            var user = await _repository.FindByUsernameAsync(loginDto.UserName!);
            if (user == null)
            {
                return Unauthorized();
            }
         
            // Check the password
            if (!_repository.VerifyPassword(user,loginDto.Password!))
            {
                return Unauthorized();
            }

            var token = JwtTokenHelper.createJwtToken(user, Token, Issuer, Audience);

            return Ok(token);
        }


    }
}

