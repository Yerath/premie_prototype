using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthenticatieService.Interfaces;
using EndpointService.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EndpointServiceTests.Middleware
{
    [TestClass]
    public class AuthenticatieMiddlewareTest
    {
        private AuthenticatieMiddleware _sut;
        private Mock<RequestDelegate> _delegateMock;
        private Mock<IAuthenticatieService> _serviceMock;
        private DefaultHttpContext _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = new DefaultHttpContext();
            _delegateMock = new Mock<RequestDelegate>();

            _serviceMock = new Mock<IAuthenticatieService>(MockBehavior.Strict);
            _serviceMock.Setup(f => f.IsTokenValid("TOKEN")).Returns(Task.FromResult(true)).Verifiable();
            _serviceMock.Setup(f => f.IsTokenValid("INVALIDTOKEN")).Returns(Task.FromResult(false)).Verifiable();


            _sut = new AuthenticatieMiddleware(_delegateMock.Object, _serviceMock.Object);
        }

        [TestMethod]
        public void ShouldExtractTokenAndCallIsTokenValid()
        {
            _context.Request.Headers["Authorization"] = "TOKEN";
            _sut.InvokeAsync(_context);
            _serviceMock.Verify(f => f.IsTokenValid("TOKEN"), Times.Once);
        }

        [TestMethod]
        public void ShouldReturn401WithCorrectMessageIfTokenIsInvalid()
        {
            _context.Request.Headers["Authorization"] = "INVALIDTOKEN";
            
            Task result = _sut.InvokeAsync(_context);
            HttpResponse _t = (HttpResponse) result.AsyncState;
            _t.StatusCode.ShouldBe(401);
        }

    }
}
