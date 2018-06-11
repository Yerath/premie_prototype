using System;
using System.Fabric;
using System.Numerics;
using LicentieService;
using LicentieService.Exceptions;
using LicentieService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace LicentieServiceTests
{
    [TestClass]
    public class LicentieServiceEndpointTest
    {
        private LicentieServiceEndpoint _sut;
        private Mock<ILicentieController> _controllerMock;


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

            _controllerMock = new Mock<ILicentieController>(MockBehavior.Strict);
            _controllerMock.Setup(f => f.Login("test", "123")).Returns("token").Verifiable();
            _controllerMock.Setup(f => f.Login("fail", "123")).Throws(new InvalidUserException("User not found"));

            _sut = new LicentieServiceEndpoint(context, _controllerMock.Object);
        }

        [TestMethod]
        public void LoginShouldCallControllerAndReturnTokenOnSuccess()
        {
            var result = _sut.Login("test", "123");
            _controllerMock.Verify(f => f.Login("test", "123"), Times.Once);
            result.Result.ShouldBe("token");
        }

        [TestMethod]
        public void LoginShouldRethrowTheExceptionToTheWebservice()
        {
            Should.Throw<InvalidUserException>(() => { _sut.Login("fail", "123"); }).Message.ShouldBe("User not found");
        }
    }
}
