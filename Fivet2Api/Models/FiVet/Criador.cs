using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Criador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual Pais Pais { get; set; }

    }
    public class CriadorDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public PaisDTO Pais { get; set; }

        public CriadorDTO()
        {
        }

        public CriadorDTO(Criador x)
        {
            ID = x.ID;
            Nombre= x.Nombre;
            Pais = new PaisDTO() { ID = x.Pais.ID, Descripcion = x.Pais.Descripcion };
        }
    }
}
