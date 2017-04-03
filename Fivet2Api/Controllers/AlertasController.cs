using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System.Globalization;

namespace Fivet2Api.Controllers
{
    public class AlertasController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Alertas/61/5
        [Route("api/Alertas/{caballo}/{tipo}")]
        public IQueryable<Alerta> GetAlerta(string name = "", int limit = 0, int offset = 0, int caballo = 0, int tipo = 1)
        {
            TipoAlertasEnum tipoEnum = (TipoAlertasEnum)tipo;

            IQueryable<Alerta> alertas = db.Alertas.Where(x => (caballo != 0 && x.Caballo.ID == caballo) && (x.Tipo == tipoEnum));

            if (offset != 0)
                alertas.Skip(offset);
            if (limit != 0)
                alertas.Take(offset);
            return alertas;
        }

        // GET: api/Alertas
        [Route("api/Alertas/{propietario}")]
        public IQueryable<Alerta> GetAlerta(string name = "", int limit = 0, int offset = 0, int propietario = 0)
        {
            IQueryable<Alerta> alertas = db.Alertas;

            if (offset != 0)
                alertas.Skip(offset);
            if (limit != 0)
                alertas.Take(offset);
            return alertas;
        }

        // GET: api/Alertas/5
        [ResponseType(typeof(Alerta))]
        public IHttpActionResult GetAlertaById(int id)
        {
            Alerta alerta = db.Alertas.Find(id);
            if (alerta == null)
            {
                return NotFound();
            }

            return Ok(alerta);
        }

        // PUT: api/Alertas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlerta(int id, Alerta alerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alerta.ID)
            {
                return BadRequest();
            }

            db.Entry(alerta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Alertas
        [HttpPost, ResponseType(typeof(AlertaDTO))]
        public IHttpActionResult PostAlerta(AlertaDTO alertaDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Alertas.Add(alerta);
            //db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = alerta.ID }, alerta);
            try
            {
                Alerta alerta = new Alerta();
                alerta.Titulo = alertaDTO.Titulo;
                alerta.FechaNotificacion = alertaDTO.FechaNotificacion;
                alerta.HoraNotificacion = alertaDTO.HoraNotificacion;
                alerta.Tipo = (TipoAlertasEnum)alertaDTO.TipoAlerta;
                alerta.Activa = alertaDTO.Activa;
                alerta.Descripcion = alertaDTO.Descripcion;
                alerta.Caballo = db.Caballos.FirstOrDefault(x => x.ID == alertaDTO.CaballoId);

                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

                db.Alertas.Add(alerta);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = alerta.ID }, alerta);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString()));
            }
        }

        // DELETE: api/Alertas/5
        [ResponseType(typeof(Alerta))]
        public IHttpActionResult DeleteAlerta(int id)
        {
            Alerta alerta = db.Alertas.Find(id);
            if (alerta == null)
            {
                return NotFound();
            }

            db.Alertas.Remove(alerta);
            db.SaveChanges();

            return Ok(alerta);
        }

        // DELETE: api/Alertas
        [Route("api/alertas/DeleteAlertasByIds")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAlertasByIds([FromUri] int[] idList)
        {
            foreach (int id in idList)
            {
                Alerta alerta = db.Alertas.Find(id);
                if (alerta == null)
                {
                    return NotFound();
                }

                db.Alertas.Remove(alerta);
            }

            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertaExists(int id)
        {
            return db.Alertas.Count(e => e.ID == id) > 0;
        }

        [Route("api/alertas/GetFecha")]
        public IHttpActionResult GetFecha()
        {
            try
            {
                DateTime date = DateTime.Now;
                CultureInfo cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");
                DateTimeFormatInfo dateFormatInfo = cultureInfo.DateTimeFormat;
                string dateString = string.Format("{0}, {1} de {2} de {3}", dateFormatInfo.GetDayName(date.DayOfWeek), date.Day, dateFormatInfo.GetMonthName(date.Month), date.Year);
                return Ok(dateString);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.ToString()));
            }
        }
    }
}
