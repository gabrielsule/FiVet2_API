using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Pelaje
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }

    public class PelajeDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}