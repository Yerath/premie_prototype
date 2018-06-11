using System;
using LicentieService.Controllers;
using LicentieService.Exceptions;
using LicentieService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace LicentieServiceTests.Controllers
{
    [TestClass]
    public class LicentieControllerTest
    {
        private LicentieController _sut;
        private Mock<ILicentieAgent> _agentMock;

        [TestInitialize]
        public void Initialize()
        {
            _agentMock = new Mock<ILicentieAgent>(MockBehavior.Strict);

            _agentMock.Setup(f => f.RetrieveToken("test", "123"))
                .Returns("Token")
                .Verifiable();

            _agentMock.Setup(f => f.RetrieveToken("throw", "123"))
                .Throws(new InvalidUserException("User not found"))
                .Verifiable();

            _sut = new LicentieController(_agentMock.Object);
        }

        [TestMethod]
        public void LoginShouldCallRetrieveTokenFromAgentAndReturnTheToken()
        {
            var result = _sut.Login("test", "123");
            _agentMock.Verify(f => f.RetrieveToken("test", "123"));
            result.ShouldBe("Token");
        }

        [TestMethod]
        public void LoginShouldRethrowExpectionFromAgent()
        {
            Should.Throw<InvalidUserException>(() => { _sut.Login("throw", "123"); })
                .Message.ShouldBe("User not found");
        }
    } 
}