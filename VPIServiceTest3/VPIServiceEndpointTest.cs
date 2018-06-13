using System;
using System.Fabric;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using VPIService;
using VPIService.Interfaces;

namespace VPIServiceTest
{
    [TestClass]
    public class VPIServiceEndpointTest
    {
        private Mock<IVPIController> _controllerMock;
        private VPIServiceEndpoint _sut;

        [TestInitialize]
        public void Initialize()
        {
            //It's a pity it couldn't be mocked.
            StatelessServiceContext context = new StatelessServiceContext(
                new NodeContext("0.0.0.0",
                    new NodeId(new BigInteger(3), new BigInteger(1)),
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

            _controllerMock = new Mock<IVPIController>(MockBehavior.Strict);
            _controllerMock.Setup(f => f.GeefToken()).Returns("token");

            _sut = new VPIServiceEndpoint(context, _controllerMock.Object);
        }

        [TestMethod]
        public void EndpointShouldReturnTokenFromTheController()
        {
            var result = _sut.BerekenPremie();
            result.Result.ShouldBe("token");
        }
    }
}
