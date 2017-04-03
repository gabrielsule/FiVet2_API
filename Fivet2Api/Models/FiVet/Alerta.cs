using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public enum TipoAlertasEnum
    {
        HERRAJE,
        DESPARACITACION,
        EVENTOS,
        DENTISTA,
        NOTASVARIAS
    }


    public class Alerta
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public string HoraNotificacion { get; set; }
        public TipoAlertasEnum Tipo { get; set; }
        public bool Activa { get; set; }
        public string Descripcion { get; set; }
        [JsonIgnore]
        public virtual Caballo Caballo { get; set; }
    }

    //public class AlertaDTO
    //{
    //    public int ID { get; set; }
    //    public string Titulo { get; set; }
    //    public DateTime FechaNotificacion { get; set; }
    //    public int HoraNotificacion { get; set; }
    //    public TipoAlertasEnum Tipo { get; set; }
    //    public bool Activa { get; set; }
    //    public string Descripcion { get; set; }

    //    public AlertaDTO() { }

    //    public AlertaDTO(Alerta x)
    //    {
    //        this.ID = x.ID;
    //        this.Titulo = x.Titulo;
    //        this.FechaNotificacion = x.FechaNotificacion;
    //        this.HoraNotificacion = x.HoraNotificacion;
    //        this.Tipo = x.Tipo;
    //        this.Activa = x.Activa;
    //        this.Descripcion = x.Descripcion;

    //    }
    //}

    public class AlertaDTO
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime FechaNotificacion { get; set; }
        public string HoraNotificacion { get; set; }
        public int TipoAlerta { get; set; }
        public bool Activa { get; set; }
        public string Descripcion { get; set; }
        public int CaballoId { get; set; }

        public AlertaDTO() { }
    }

}