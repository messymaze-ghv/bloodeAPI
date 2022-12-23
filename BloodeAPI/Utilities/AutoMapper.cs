using System;
using AutoMapper;
using BloodeAPI.ViewModels.Request.Auth;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Response;

namespace BloodeAPI.Utilities
{
	public class AutoMapper:Profile
	{
		public AutoMapper()
		{
			CreateMap<RegisterRequest, User>();
			CreateMap<User, RegisterResponse>();
        }
    }
}

