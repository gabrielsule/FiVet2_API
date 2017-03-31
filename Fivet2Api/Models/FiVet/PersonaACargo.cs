using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class PersonaACargo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
    }
    public class PersonaACargoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }

        public PersonaACargoDTO() {}

        public PersonaACargoDTO(PersonaACargo x)
        {
            if (x != null)
            {
                ID = x.ID;
                Nombre = x.Nombre;
                Telefono = x.Telefono;
                Mail = x.Mail;
            }
        }
    }
}
