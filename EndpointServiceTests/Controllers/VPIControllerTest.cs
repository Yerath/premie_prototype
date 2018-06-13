using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EndpointService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using VPIService.Interfaces;

namespace EndpointServiceTests.Controllers
{
    [TestClass]
    public class VPIControllerTest
    {
        private VPIController _sut;
        private Mock<IVPIService> _serviceMock;

        [TestInitialize]
        public void Initialize()
        {
            _serviceMock = new Mock<IVPIService>(MockBehavior.Strict);
            _serviceMock.Setup(f => f.BerekenPremie()).Returns(Task.FromResult("message"));

            _sut = new VPIController(_serviceMock.Object);
        }

        [TestMethod]
        public void ControllerShouldReturnResultFromService()
        {
            var result = _sut.Index() as ContentResult;
            result?.Content.ShouldBe("message");
        }

    }
}
