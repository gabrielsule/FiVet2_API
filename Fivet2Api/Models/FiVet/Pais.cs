using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Pais
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<EstadoProvincia> EstadosProvincias { get; set; }

        public Pais()
        {
            EstadosProvincias = new List<EstadoProvincia>();
        }
    }

    public class PaisDTO
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public List<EstadoProvinciaDTO> EstadosProvincias { get; set; }

        public PaisDTO()
        {
            EstadosProvincias = new List<EstadoProvinciaDTO>();
        }
    }
}