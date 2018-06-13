using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using VPIService.Controllers;
using VPIService.Interfaces;

namespace VPIServiceTest.Controllers
{
    [TestClass]
    public class VPIControllerTest
    {
        private VPIController _sut;
        private Mock<IVPIAgent> _agentMock;
        
        [TestInitialize]
        public void Initialize()
        {
            _agentMock = new Mock<IVPIAgent>(MockBehavior.Strict);
            _sut = new VPIController(_agentMock.Object);
        }

        [TestMethod]
        public void ControllerShouldReturnTokenIfNoExceptionIsThrown()
        {
            _agentMock.Setup(f => f.GetToken()).Returns("token");
            var result = _sut.GeefToken();
            result.ShouldBe("token");
        }

        [TestMethod]
        public void ControllerShouldReturnExceptionMessageWhenAgentThrowsException()
        {
            _agentMock.Setup(f => f.GetToken()).Throws(new Exception("VPI webservice call (token opvragen) failed"));
            var result = _sut.GeefToken();
            result.ShouldBe("VPI webservice call (token opvragen) failed");
        }
    }
}
