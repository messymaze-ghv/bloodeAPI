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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodeAPI.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : Controller,IAuthentication
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly BlooddonateContext dbCtx;
        private readonly IMapper _mapper;


        public AuthController(ILogger<WeatherForecastController> logger,BlooddonateContext ctx, IMapper mapper)
        {
            this.logger = logger;
            this._mapper = mapper;
            this.dbCtx = ctx;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                if (request.UserName != null && request.Password != null)
                {
                    var username = request.UserName;
                    var password = request.Password.GenerateHashing();
                    var user = this.dbCtx.Users.Where(ind => (ind.Email == request.UserName || ind.PhoneNumber == request.UserName)).Single();
                    return Ok(user.Password == HashUtils.GenerateHashing(request.Password));

                }
                return new BadRequestResult();
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        [HttpPost("Register")]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            try
            {
                request.Password = HashUtils.GenerateHashing(request!.Password!);
                var dbUser = this._mapper.Map<User>(request);
                this.dbCtx.Users.Add(dbUser);
                this.dbCtx.SaveChanges();
                return Ok(true);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

    }
}

