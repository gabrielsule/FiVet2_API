using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Genero
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }

    public class GeneroDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}