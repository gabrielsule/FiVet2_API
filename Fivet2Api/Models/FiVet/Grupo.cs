using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Grupo
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Caballo> Caballos { get; set; }

        public Grupo() {
            Caballos = new List<Caballo>();
        }

    }

    public class GrupoDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<CaballoDTO> Caballos { get; set; }

        public GrupoDTO()
        {
            Caballos = new List<CaballoDTO>();
        }

    }
}