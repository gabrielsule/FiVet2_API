using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Propietario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual EstadoProvincia EstadoProvincia { get; set; }
    }


    public class PropietarioDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public EstadoProvinciaDTO EstadoProvincia { get; set; }

        public PropietarioDTO()
        {
        }

        public PropietarioDTO(Propietario x)
        {
            ID = x.ID;
            Nombre = x.Nombre;
            Apellido = x.Apellido;
            Mail = x.Mail;
            Celular = x.Celular;
            FechaNacimiento = x.FechaNacimiento;
            EstadoProvincia = new EstadoProvinciaDTO() { Id = x.EstadoProvincia.Id, Nombre = x.EstadoProvincia.Nombre, Pais = new PaisDTO() { ID = x.EstadoProvincia.Pais.ID, Descripcion = x.EstadoProvincia.Pais.Descripcion } };
        }

    }

}