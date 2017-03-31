using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{

    public class Evento
    {
        public int ID { get; set; }
        public virtual Alerta Alerta {get;set;}        
        public int? DiasPreviosaNotificar { get; set; }        
    }


    public class EventoDTO
    {
        public int ID { get; set; }
        public  AlertaDTO Alerta { get; set; }
        public int? DiasPreviosaNotificar { get; set; }

        public EventoDTO() { }

        public EventoDTO(Evento x) {
            this.ID = x.ID;
            //this.Alerta = new AlertaDTO(x.Alerta);
            this.DiasPreviosaNotificar = x.DiasPreviosaNotificar;
        }

    }

}