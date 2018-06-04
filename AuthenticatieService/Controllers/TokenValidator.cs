using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthenticatieService.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticatieService.Controllers
{
    public class TokenValidator: ITokenValidator
    {
        public bool ValidateToken(string token)
        {
            try
            {
                ValidateTokenWithParameters(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        private void ValidateTokenWithParameters(string token)
        {
            var validationParameters = new TokenValidationParameters()
            {
                ValidIssuer = "UNIT4",
                //TODO: Wellicht willen we de key ophalen van de licentie server? 
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnm123456")),
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.ValidateToken(token, validationParameters, out _);
        }
    }
}
