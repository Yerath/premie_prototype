using System;
using System.Collections.Generic;
using System.Text;
using RollsService.Entities;
using RollsService.Interfaces;

namespace RollsService.Agents
{
    public class RollsAgent : IRollsAgent
    {
        public PersonenautoWAMiniCasco BerekenPremiePersonenAutoWAMiniCasco(string bsn, DateTime verjaardag, string kenteken)
        {
            var result = new PersonenautoWAMiniCasco
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

            return result;
        }
    }
}
