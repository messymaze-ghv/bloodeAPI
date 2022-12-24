using System;
using BloodeAPI.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BloodeAPI.Utilities
{
	public class JwtTokenExtracter
	{
        public string? GetUserId(string token)
        {
            // Parse the token
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);

            // Get the claims from the token
            var claims = securityToken.Claims;

            // Find the user ID claim
            var userIdClaim = claims.FirstOrDefault(c => c.Type == "sub");

            // Get the user ID from the claim
            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }
            else
            {
                return null;
            }
        }
    }

}

