using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EndpointService.Controllers;
using LicentieService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EndpointServiceTests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        private LoginController _sut;
        private Mock<ILicentieService> _serviceMock;
       

        [TestInitialize]
        public void Initiliaze()
        {
            _serviceMock = new Mock<ILicentieService>(MockBehavior.Strict);
            _serviceMock.Setup(f => f.Login("user", "passwrd")).Returns(Task.FromResult("token"));

            _sut = new LoginController(_serviceMock.Object);
        }

        [TestMethod]
        public void IndexShouldReturnAGenericMessage()
        {
            var result = _sut.Index() as ContentResult;
            result?.Content.ShouldBe("PremiePrototype is functioning normally");
        }

        [TestMethod]
        public void LoginPostShouldReturnTokenIfUserIsValid()
        {
            var result = _sut.Post("user", "password") as ContentResult;
            result?.Content.ShouldBe("token");
        }

        [TestMethod]
        public void LoginPostShouldReturnNotFoundIfUserIsInvalid()
        {
            var result = _sut.Post("user", "password");
            result.ShouldBeOfType<NotFoundResult>();
        }


    }
}
