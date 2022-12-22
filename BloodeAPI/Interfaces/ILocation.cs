using System;
using BloodeAPI.ViewModels.Request;
using BloodeAPI.ViewModels.Request.Location;
using Microsoft.AspNetCore.Mvc;

namespace BloodeAPI.Interfaces
{
	public interface ILocation
	{
		public List<String?> GetStates();
		public List<String?> GetDistricts(DistrictsRequest location);
		public List<String> GetCities(CitiesRequest location);

	}
}

