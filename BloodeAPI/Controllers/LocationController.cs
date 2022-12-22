using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodeAPI.ViewModels.Request;
using BloodeAPI.ViewModels.Request.Location;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller,ILocation
    {
        private readonly List<IndianStates?>? Locations = JsonHelper.LoadJson<List<IndianStates?>>(StringUtils.GetStatesJsonFilePath());

        [HttpGet("FetchCities")]
        public List<string> GetCities([FromBody] CitiesRequest location)
        {
            var districts = Locations!.Where((arg) => arg!.Name == location.State).SelectMany(d => d!.DistrictList!).ToList();
            return districts!.Where(d => d!.Name == location.District).SelectMany(d => d!.CitiesList!).ToList();
            
        }

        [HttpPost("FetchDistricts")]
        public List<string?> GetDistricts([FromBody] DistrictsRequest location)
        {
            var districts =  Locations!.Where((arg) => arg!.Name == location.State).SelectMany(d=> d!.DistrictList!).ToList();
            var districtNames =  districts!.Select(d => d!.Name).ToList();
            return districtNames;
        }

        [HttpGet("FetchStates")]
        public List<string?> GetStates()
        {
            var stateNames =  Locations!.Select(d => d!.Name).ToList();
            return stateNames;
        }
    }
}

