using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fivet2Api.Models.FiVet
{
    public class CaballoSerial
    {
        public string Nombre { get; set; }
        public string Establo { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? FechaNacimiento { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string NumeroChip { get; set; }
        public int? NumeroFEI { get; set; }
        public bool EstadoFEI { get; set; }
        public string Protector { get; set; }
        public string Embocadura { get; set; }
        public string ExtrasDeCabezada { get; set; }
        public bool? ADN { get; set; }
        public string NumeroId { get; set; }
        public int? NumeroFEN { get; set; }
        public bool EstadoFEN { get; set; }
        public int? Genero { get; set; }
        public int? Pelaje { get; set; }
        public int? EstadoProvincia { get; set; }
        public int? Propietario { get; set; }
        public int? Criador { get; set; }

        public CaballoSerial()
        {

        }
    }

}