using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EndpointService.Controllers;
using EndpointService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RollsService.Interfaces;
using Shouldly;

namespace EndpointServiceTests.Controllers
{
    [TestClass]
    public class RollsControllerTest
    {
        private RollsController _sut;
        private Mock<IRollsService> _serviceMock;
        private RollsService.Entities.PersonenautoWAMiniCasco _personenautoWaMiniCasco;

        [TestInitialize]
        public void Initialize()
        {
            _personenautoWaMiniCasco = CreatePersonenautoWaMiniCasco();

            _serviceMock = new Mock<IRollsService>(MockBehavior.Strict);
            _serviceMock.Setup(f => f.BerekenPremiePersonenAutoWAMiniCasco(It.IsAny<string>(), It.IsAny<DateTime>(),
                    It.IsAny<string>()))
                .Returns(
                    Task.FromResult(_personenautoWaMiniCasco)
                );

            _sut = new RollsController(_serviceMock.Object);
        }

        [TestMethod]
        public void EndpointShouldReturnThePersonenautoWAMiniCascoInJson()
        {
            var result = _sut.Index() as ContentResult;
            var mappedObject = Mapper.Map<PersonenautoWAMiniCasco>(_personenautoWaMiniCasco);
            result?.Content.ShouldBe(JsonConvert.SerializeObject(mappedObject));
        }

        private RollsService.Entities.PersonenautoWAMiniCasco CreatePersonenautoWaMiniCasco()
        {
            return new RollsService.Entities.PersonenautoWAMiniCasco
            {
                WAWettelijkeAansprakelijkheid =
                    new RollsService.Entities.Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                BMNoClaim =
                    new RollsService.Entities.Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                Casco =
                    new RollsService.Entities.Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                POI =
                    new RollsService.Entities.Dekking()
                    {
                        Beschrijving = "WA Wettelijke Aanspraakelijkheid dekking",
                        Brutopremie = "300",
                        DekkingCode = "AJSD1E",
                        Naam = "WA"
                    },
                Rechtsbijstands =
                    new RollsService.Entities.Dekking()
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
