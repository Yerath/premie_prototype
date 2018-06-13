using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RollsService.Agents;
using RollsService.Entities;
using Shouldly;

namespace RollsServiceTests.Agents
{
    [TestClass]
    public class RollsAgentTest
    {
        private PersonenautoWAMiniCasco _personenautoWaMiniCasco;
        private RollsAgent _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new RollsAgent();
        }

        [TestMethod]
        public void RollsAgentShouldReturnAPersonenautoWAMiniCasco()
        {
            var result = _sut.BerekenPremiePersonenAutoWAMiniCasco("2345456435", DateTime.Now, "test");
            result.ShouldBeOfType< PersonenautoWAMiniCasco>();
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
