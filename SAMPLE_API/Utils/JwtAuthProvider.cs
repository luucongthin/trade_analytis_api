using Microsoft.IdentityModel.Tokens;
using SAMPLE_API.Business.User;
using SAMPLE_API.Common;
using SAMPLE_API.Models.UserDTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SAMPLE_API.Utils
{
    public class JwtAuthProvider  
    {
        private static string Secret = Signature.GenerateSecret("abc1234");

        public static string GenerateToken(string username, string password)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            UserDTO data = UserBUS.CheckUserLogin(username, password, 1);
            int id = data.ID;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, id.ToString())
                    }),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string tokenFull)
        {
            string token = tokenFull != "" ? tokenFull.Substring(7, tokenFull.Length -7) : null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }

        //private static bool ValidateToken(string token, out string username)
        public static int ValidateToken(string token)
        {
            int id;
            var simplePrinciple = GetPrincipal(token);
            if(simplePrinciple != null)
            {
                var identity = simplePrinciple.Identity as ClaimsIdentity;
                if (identity == null) return 0;
                if (!identity.IsAuthenticated) return 0;
                var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                id = Convert.ToInt16(usernameClaim?.Value);
                return id;
            }else
            {
                return 0;
            }
        }


    }
}