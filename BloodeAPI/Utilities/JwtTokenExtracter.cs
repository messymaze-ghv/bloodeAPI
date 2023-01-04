using System;
using BloodeAPI.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BloodeAPI.Utilities
{
	public class JwtTokenHelper
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
        public static String createJwtToken(User user, string securityToken,string issuer, string audince )
        {

            // Generate a JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityToken));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(60),
                SigningCredentials = creds,
                Issuer = issuer,
                Audience = audince
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var returnToken = tokenHandler.WriteToken(token);
            return returnToken;
        }

    }

}

