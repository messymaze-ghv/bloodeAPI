using System;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Request.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BloodeAPI.Interfaces
{
    public interface IAuthRepository
	{
		public Task<User> CreateAsync(User user);
		public Task<User> FindByUsernameAsync(string username);
		public bool VerifyPassword(User user, string password);
    }
}

