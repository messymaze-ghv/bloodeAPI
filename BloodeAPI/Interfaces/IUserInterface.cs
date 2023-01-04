using System;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Request;
using BloodeAPI.ViewModels.Response;

namespace BloodeAPI.Interfaces
{
	public interface IUserInterface
	{
        public Task<User?> GetUser(int id);
    }
}

