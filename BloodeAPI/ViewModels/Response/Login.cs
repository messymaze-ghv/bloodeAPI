using System;
namespace BloodeAPI.ViewModels.Response
{
	/// <summary>
	/// Returning login response
	/// </summary>
	public class LoginResponseModel
	{
		/// <summary>
		/// Returns true if successful login
		/// </summary>
		public bool IsLoggedIn { get; set; }
		/// <summary>
		/// Returns a userId if login else null
		/// </summary>
		public Guid UserId { get; set; }
	}
}

