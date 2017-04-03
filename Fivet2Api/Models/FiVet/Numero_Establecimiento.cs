using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Numero_Establecimiento
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public virtual Tipo_Numero Tipo { get; set; }
        [JsonIgnore]
        public virtual Establecimiento Establecimiento { get; set; }
        
    }

    public class Numero_EstablecimientoDTO
    {
        public int ID { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
        public string Numero { get; set; }
        public Tipo_NumeroDTO Tipo { get; set; }

        public Numero_EstablecimientoDTO()
        {
        }

        public Numero_EstablecimientoDTO(Numero_Establecimiento x)
        {
            ID = x.ID;
            Establecimiento = new EstablecimientoDTO(x.Establecimiento);
            Numero = x.Numero;
            Tipo = new Tipo_NumeroDTO(x.Tipo);
        }
    }
}