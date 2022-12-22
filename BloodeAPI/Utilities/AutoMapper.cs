using System;
using AutoMapper;
using BloodeAPI.ViewModels.Request.Auth;
using BloodeAPI.Models;

namespace BloodeAPI.Utilities
{
	public class AutoMapper:Profile
	{
		public AutoMapper()
		{
			CreateMap<SignupRequest, User>();
        }
    }
}

