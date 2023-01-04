using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BloodeAPI.Utilities
{
   public class TokenService
        {
            public static int GetUserIdFromRequest(HttpRequest request)
            {
                // Get the JWT token from the request header
                string authHeader = request.Headers["Authorization"]!;
                string jwtToken = authHeader.Split(" ").Last();

                // Decode the JWT token to get the user ID
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadToken(jwtToken) as JwtSecurityToken;
                var claim = token!.Claims.ToList()[0];
                return int.Parse(claim.Value);
            }
        }
}

