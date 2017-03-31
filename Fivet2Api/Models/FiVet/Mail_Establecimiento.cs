using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Mail_Establecimiento
    {
        public int ID { get; set; }
        public string MailDesc { get; set; }
        public virtual Tipo_Mail Tipo { get; set; }
        [JsonIgnore]
        public virtual Establecimiento Establecimiento { get; set; }
    }

    public class Mail_EstablecimientoDTO
    {
        public int ID { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
        public string MailDesc { get; set; }
        public Tipo_MailDTO Tipo { get; set; }

        public Mail_EstablecimientoDTO()
        {
        }

        public Mail_EstablecimientoDTO(Mail_Establecimiento x)
        {
            ID = x.ID;
            Establecimiento = new EstablecimientoDTO(x.Establecimiento);
            MailDesc = x.MailDesc;
            Tipo = new Tipo_MailDTO(x.Tipo);
        }
    }
}