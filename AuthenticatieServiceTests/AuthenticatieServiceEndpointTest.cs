using System;
using System.Fabric;
using System.Numerics;
using AuthenticatieService;
using AuthenticatieService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace AuthenticatieServiceTests
{
    [TestClass]
    public class AuthenticatieServiceEndpointTest
    {
        private AuthenticatieServiceEndpoint _sut;
        private Mock<ITokenValidator> _validatorMock;


        [TestInitialize]
        public void Initialize()
        {
            //It's a pity it couldn't be mocked.
            StatelessServiceContext context = new StatelessServiceContext(
                new NodeContext("0.0.0.0", 
                    new NodeId(new BigInteger(3),new BigInteger(1)), 
                    new BigInteger(1), 
                    "Node1", 
                    "some"
                ), 
                new Mock<ICodePackageActivationContext>().Object, 
                "aaaType", 
                new Uri("fabric:/aaa"), 
                null, 
                new Guid(), 
                1
            );

            _validatorMock = new Mock<ITokenValidator>(MockBehavior.Strict);
            _validatorMock.Setup(f => f.ValidateToken(It.IsAny<string>())).Returns(true).Verifiable();

            _sut = new AuthenticatieServiceEndpoint(context, _validatorMock.Object);
        }

        [TestMethod]
        public void IsTokenValidShouldCallTokenValidatorIfHeaderIsFilled()
        {
            _sut.IsTokenValid("testtoken");
            _validatorMock.Verify(f => f.ValidateToken("testtoken"), Times.Once);
        }

        [TestMethod]
        public void IsTokenValidShouldNotCallTokenValidatorIfHeaderIsEmptyAndShouldReturnFalse()
        {
            var result = _sut.IsTokenValid("");
            _validatorMock.Verify(f => f.ValidateToken(""), Times.Never);
            result.Result.ShouldBeFalse();
        }

    }
}
