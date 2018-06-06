using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticatieService.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AuthenticatieServiceTests.Controllers
{
    [TestClass]
    public class TokenValidatorTest
    {
        private TokenValidator _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new TokenValidator();
        }


        [TestMethod]
        public void TokenValidatorShouldReturnTrueWhenSignatureAndIssuerAreValid()
        {
            var token = createTokenString("qwertyuiopasdfghjklzxcvbnm123456", "UNIT4");
            var result = _sut.ValidateToken(token);

            result.ShouldBeTrue();
        }

        [TestMethod]
        public void TokenValidatorShouldReturnFalseWhenSignatureIsValidbutIssuerInvalid()
        {
            var token = createTokenString("qwertyuiopasdfghjklzxcvbnm123456", "UNIT5");
            var result = _sut.ValidateToken(token);

            result.ShouldBeFalse();
        }

        [TestMethod]
        public void TokenValidatorShouldReturnFalseWhenSignatureIsInvalid()
        {
            var token = createTokenString("qwertyuiopasdfghjretfxcvbnm123456", "UNIT4");
            var result = _sut.ValidateToken(token);

            result.ShouldBeFalse();
        }

        private string createTokenString(string secretKey, string issuer)
        {
            var credentials = new SigningCredentials
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credentials);
            var claims = new List<Claim>
            {
                new Claim("iss", issuer, ClaimValueTypes.String)
            };


            var payload = new JwtPayload(claims);

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }
    }

}
