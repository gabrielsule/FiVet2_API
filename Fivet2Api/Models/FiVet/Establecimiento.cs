using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Establecimiento
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Propietario { get; set; }
        public string Ubicacion { get; set; }
        public string DescUbicacion { get; set; }
        public virtual ICollection<Mail_Establecimiento> Mails { get; set; }
        public virtual ICollection<Numero_Establecimiento> Numeros { get; set; }

        public Establecimiento()
        {
            Mails = new List<Mail_Establecimiento>();
            Numeros = new List<Numero_Establecimiento>();
        }
    }
    public class EstablecimientoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Propietario { get; set; }
        public string Ubicacion { get; set; }
        public string DescUbicacion { get; set; }
        public List<Mail_EstablecimientoDTO> Mails { get; set; }
        public List<Numero_EstablecimientoDTO> Numeros { get; set; }

        public EstablecimientoDTO()
        {
            Mails = new List<Mail_EstablecimientoDTO>();
            Numeros = new List<Numero_EstablecimientoDTO>();
        }

        public EstablecimientoDTO(Establecimiento x)
        {
            if (x != null)
            {
                ID = x.ID;
                Nombre = x.Nombre;
                Propietario = x.Propietario;
                Ubicacion = x.Ubicacion;
                DescUbicacion = x.DescUbicacion;
                Mails = new List<Mail_EstablecimientoDTO>();
                foreach (Mail_Establecimiento mail in x.Mails)
                    Mails.Add(new Mail_EstablecimientoDTO() { MailDesc = mail.MailDesc, Tipo = new Tipo_MailDTO(mail.Tipo) });
                Numeros = new List<Numero_EstablecimientoDTO>();
                foreach (Numero_Establecimiento numeroTelefono in x.Numeros)
                    Numeros.Add(new Numero_EstablecimientoDTO() { Numero = numeroTelefono.Numero, Tipo = new Tipo_NumeroDTO(numeroTelefono.Tipo) });
            }
        }
    }
}
