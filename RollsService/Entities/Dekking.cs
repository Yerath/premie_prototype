using System;
using System.Collections.Generic;
using System.Text;

namespace RollsService.Entities
{
    [Serializable]
    public class Dekking
    {
        public string DekkingCode { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Brutopremie { get; set; }
    }
}
