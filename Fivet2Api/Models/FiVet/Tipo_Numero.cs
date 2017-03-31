using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Tipo_Numero
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Tipo_Numero()
        {
        }
    }

    public class Tipo_NumeroDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Tipo_NumeroDTO() { }

        public Tipo_NumeroDTO(Tipo_Numero x)
        {
            ID = x.ID;
            Descripcion = x.Descripcion;
        }
    }
}