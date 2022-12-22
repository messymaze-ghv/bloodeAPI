using System;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Request.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BloodeAPI.Interfaces
{
    public interface IAuthentication
	{
		public IActionResult Signup(SignupRequest request);
		public IActionResult Login(LoginRequest request);
	}
}

