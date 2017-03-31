using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class EstadoProvincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        public virtual  Pais Pais { get; set; }
    }

    public class EstadoProvinciaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public PaisDTO Pais { get; set; }

    }
}