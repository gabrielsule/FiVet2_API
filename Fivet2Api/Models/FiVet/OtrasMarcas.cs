using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class OtrasMarcas
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }

    public class OtrasMarcasDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}