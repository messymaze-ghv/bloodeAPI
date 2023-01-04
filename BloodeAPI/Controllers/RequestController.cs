using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Request.RequestDTO;
using BloodeAPI.ViewModels.Request.Location;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Net.Http.Headers;
using BloodeAPI.Utilities;
using BloodeAPI.ViewModels.Response;

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

        [HttpGet]
        [Route("AddByMe")]
        public async Task<IActionResult> GetMyRequests()
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = TokenService.GetUserIdFromRequest(Request);
            // Add the model to the repository
            var response = await _repository.FetchMyRequests(id)!;

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

        [HttpGet]
        [Route("City")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var id = TokenService.GetUserIdFromRequest(Request);
                // Add the model to the repository
                var response = await _repository.FetchRequestsByCity(id)!;
                return Ok(response);
                // Return the added model
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }


        }

        [HttpGet]
        [Route("{requestId}/Archive")]
        public async Task<IActionResult> ArchiveRequest(int requestId)
        {

            // Add the model to the repository
            var response = await _repository.MakeArchive(requestId)!;

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

        [HttpGet]
        [Route("{requestId}/Donate")]
        public async Task<IActionResult> AddToDonars(int requestId)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = TokenService.GetUserIdFromRequest(Request);

            // Add the model to the repository
            var response = await _repository.UpdateDonarsList(id, requestId)!;

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

        [HttpGet]
        [Route("{requestId}/AllDonarsDetails")]
        public  IActionResult GetDonarsList(int requestId)
        {
          
            // Add the model to the repository
            return Ok(_repository.GetDonarsDetails(requestId));
         }

    }
}

