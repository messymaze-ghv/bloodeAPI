using System;
using System.Globalization;
using BloodeAPI.Utilities;
using BloodeAPI.ViewModels.Response;

namespace BloodeAPI.ViewModels.Request.Auth
{
    /// <summary>
    /// Registering request 
    /// </summary>
	public class RegisterRequest : RegisterResponse
	{
        public string? Password { get; set; }
    }
}

