using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RollsService.Controllers;
using RollsService.Entities;
using RollsService.Interfaces;
using Shouldly;

namespace RollsServiceTests.Controllers
{
    [TestClass]
    public class RollsControllerTest
    {
        private RollsController _sut;
        private Mock<IRollsAgent> _agentMock;
        private PersonenautoWAMiniCasco _personenautoWaMiniCasco;

        [TestInitialize]
        public void Initialize()
        {
            _personenautoWaMiniCasco = CreatePersonenautoWaMiniCasco();

            _agentMock = new Mock<IRollsAgent>(MockBehavior.Strict);
            _agentMock.Setup(f => f.BerekenPremiePersonenAutoWAMiniCasco(It.IsAny<string>(), It.IsAny<DateTime>(),
                    It.IsAny<string>()))
                .Returns(
                    _personenautoWaMiniCasco
                );

            _sut = new RollsController(_agentMock.Object);
        }

        [TestMethod]
        public void ControllerShouldReturnPersonenautoWaMiniCascoFromAgent()
        {
            var result = _sut.BerekenPremiePersonenAutoWAMiniCasco("2345456435", DateTime.Now, "test");
            result.ShouldBe(_personenautoWaMiniCasco);
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
