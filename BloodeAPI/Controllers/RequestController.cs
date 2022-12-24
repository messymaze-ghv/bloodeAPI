using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Request;
using BloodeAPI.ViewModels.Request.Location;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodeAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _repository;
        private readonly IConfiguration config;
        private readonly IMapper _mapper;


        public RequestController(IRequestRepository repo, IConfiguration config, IMapper mapper)
        {
            this._repository = repo;
            this._mapper = mapper;
            this.config = config;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRequest([FromBody] RequestDTO model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the model to the repository
            var Id = await _repository.AddRequest(model);

            if (Id >= 0)
            {
                return Ok(Id);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // Return the added model
        }

        [HttpPost]
        [Route("Mine")]
        public async Task<IActionResult> GetMyRequests([FromBody] RequestDTO model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the model to the repository
            var response = await _repository.FetchMyRequests(model)!;

            if (response!=null)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // Return the added model
        }

        [HttpPost]
        [Route("All")]
        public async Task<IActionResult> GetAllRequests([FromBody] RequestDTO model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the model to the repository
            var response = await _repository.FetchRequestsByPlace(model)!;

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // Return the added model
        }

        [HttpPost]
        [Route("DoArchive")]
        public async Task<IActionResult> ArchiveRequest([FromBody] RequestDTO model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the model to the repository
            var response = await _repository.MakeArchive(model)!;

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // Return the added model
        }

        [HttpPost]
        [Route("AddToDonars")]
        public async Task<IActionResult> AddToDonars([FromBody] RequestDTO model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the model to the repository
            var response = await _repository.UpdateDonarsList(model)!;

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // Return the added model
        }

    }
}

