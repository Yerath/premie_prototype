using System.Threading.Tasks;
using AuthenticatieService.Interfaces;
using EndpointService.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EndpointServiceTests.Middleware
{
    [TestClass]
    public class AuthenticatieMiddlewareTest
    {
        private AuthenticatieMiddleware _sut;
        private HttpContext _context;

        private Mock<RequestDelegate> _delegateMock;
        private Mock<IAuthenticatieService> _serviceMock;

        [TestInitialize]
        public void Initialize()
        {
            _delegateMock = new Mock<RequestDelegate>();
            _delegateMock.Setup(f => f(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);

            _serviceMock = new Mock<IAuthenticatieService>(MockBehavior.Strict);
            _serviceMock.Setup(f => f.IsTokenValid("TOKEN")).Returns(Task.FromResult(true)).Verifiable();
            _serviceMock.Setup(f => f.IsTokenValid("INVALIDTOKEN")).Returns(Task.FromResult(false)).Verifiable();

            _context = new DefaultHttpContext();
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
        public void ShouldCallRequestDelegateWhenTokenIsValid()
        {
            _context.Request.Headers["Authorization"] = "TOKEN";
            _sut.InvokeAsync(_context);
            _delegateMock.Verify(f => f(It.IsAny<HttpContext>()), Times.Once());
        }

        [TestMethod]
        public void ShouldNotCallRequestDelegateWhenTokenIsInvalid()
        {
            _context.Request.Headers["Authorization"] = "INVALIDTOKEN";
            _sut.InvokeAsync(_context);
            _delegateMock.Verify(f => f(It.IsAny<HttpContext>()), Times.Never());
        }

    }
}
