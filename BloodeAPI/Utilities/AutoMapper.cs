using System;
using AutoMapper;
using BloodeAPI.ViewModels.Request.Auth;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Response;
using BloodeAPI.ViewModels.Request;

namespace BloodeAPI.Utilities
{
	public class AutoMapper:Profile
	{
		public AutoMapper()
		{
			CreateMap<RegisterRequest, User>();
			CreateMap<User, RegisterResponse>();
			CreateMap<RequestDTO, Request>();
        }
    }
}

