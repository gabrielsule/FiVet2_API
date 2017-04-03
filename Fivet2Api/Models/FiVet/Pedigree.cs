using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Pedigree
    {
        public int ID { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string Imagen { get; set; }
    }

    public class PedigreeDTO
    {
        public int ID { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string Imagen { get; set; }

        public PedigreeDTO() { }
        public PedigreeDTO(PedigreeDTO x)
        {
            ID = x.ID;
            Padre = x.Padre;
            Madre = x.Madre;
            Imagen = x.Imagen;

        }
    }
}