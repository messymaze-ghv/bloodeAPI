using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodeAPI.Interfaces;
using BloodeAPI.ViewModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodeAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _repository;
        private readonly IMapper _mapper;


        public UsersController(IUserInterface repo, IMapper mapper)
        {
            this._repository = repo;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Id should be greater than 0");
                }

                var user = await this._repository.GetUser(id);

                if (user == null)
                {
                    throw new Exception("Not Good");
                }
                return Ok(this._mapper.Map<RegisterResponse>(user));
            }
            catch(Exception ex)
            {
                return (IActionResult)ex;
            }
     
        }

    }
}

