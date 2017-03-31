using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Tipo_Mail
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Tipo_Mail()
        {
        }
    }

    public class Tipo_MailDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Tipo_MailDTO() { }

        public Tipo_MailDTO(Tipo_Mail x)
        {
            ID = x.ID;
            Descripcion = x.Descripcion;
        }
    }
}