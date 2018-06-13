using System;
using System.Fabric;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RollsService;
using RollsService.Entities;
using RollsService.Interfaces;
using Shouldly;

namespace RollsServiceTests
{
    [TestClass]
    public class RollsServiceEndpointTest
    {
        private RollsServiceEndpoint _sut;
        private PersonenautoWAMiniCasco _personenautoWaMiniCasco;
        private Mock<IRollsController> _controllerMock;

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
            _personenautoWaMiniCasco = CreatePersonenautoWaMiniCasco();

            _controllerMock = new Mock<IRollsController>(MockBehavior.Strict);
            _controllerMock.Setup(f =>
                    f.BerekenPremiePersonenAutoWAMiniCasco(It.IsAny<string>(), It.IsAny<DateTime>(),
                        It.IsAny<string>()))
                .Returns(
                    _personenautoWaMiniCasco
                );

            _sut = new RollsServiceEndpoint(context, _controllerMock.Object);
        }

        [TestMethod]
        public void EndpointShouldReturnPersonenautoWaMiniCascoFromController()
        {
            var result = _sut.BerekenPremiePersonenAutoWAMiniCasco("2345456435", DateTime.Now, "test");
            result.Result.ShouldBe(_personenautoWaMiniCasco);
        }


        private PersonenautoWAMiniCasco CreatePersonenautoWaMiniCasco()
        {
            return new PersonenautoWAMiniCasco
            {
                WAWettelijkeAansprakelijkheid =
                    new Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                BMNoClaim =
                    new Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                Casco =
                    new Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                POI =
                    new Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                Rechtsbijstands =
                    new Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
            };
        }
    }
}
