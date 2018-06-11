using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using LicentieService.Exceptions;
using LicentieService.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LicentieService.Agents
{
    public class LicentieAgent : ILicentieAgent
    {
        private readonly Dictionary<string, string> _knownUsers;

        public LicentieAgent()
        {
            _knownUsers = new Dictionary<string, string>
            {
                { "dimitry", "volker" }
            };
        }

        public string RetrieveToken(string username, string password)
        {
            //TODO: This should send a message to the licentie server.. but for now checks a dictionary.
            if (_knownUsers.Any(f => f.Key == username && f.Value == password))
            {
                //TODO: The server would give the token after recieving the credentials. Now we just generate a token
                return GenerateToken();
            }

            throw new InvalidUserException("User not found");
        }

        private string GenerateToken()
        {
            var credentials = new SigningCredentials
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfghjretfxcvbnm123456")), SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credentials);
            var claims = new List<Claim>
            {
                new Claim("iss", "UNIT4", ClaimValueTypes.String)
            };

            var payload = new JwtPayload(claims);

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

    }
}
