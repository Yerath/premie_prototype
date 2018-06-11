using System;
using System.Collections.Generic;
using System.Text;

namespace EndpointService.Entities
{
    [Serializable]
    public class PersonenautoWAMiniCasco
    {
        public Dekking WAWettelijkeAansprakelijkheid{ get; set; }
        public Dekking Casco { get; set; }
        public Dekking POI { get; set; }
        public Dekking BMNoClaim { get; set; }
        public Dekking Rechtsbijstands { get; set; }
    }
}
