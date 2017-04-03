using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fivet2Api.Controllers
{
    public class EstablecimientoController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Establecimiento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Establecimiento/5
        [Route("api/establecimiento/{idCaballo}")]
        [ResponseType(typeof(EstablecimientoDTO))]
        public IHttpActionResult GetEstablecimientoByIdCaballo(int idCaballo)
        {
            if (db.Caballos.FirstOrDefault(c => c.ID == idCaballo) == null)
                return NotFound();
            else if (db.Caballos.FirstOrDefault(c => c.ID == idCaballo).Establecimiento == null)
                return NotFound();

            int idEstablecimiento = db.Caballos.FirstOrDefault(c => c.ID == idCaballo).Establecimiento.ID;
            Establecimiento establecimiento = new Establecimiento();
            establecimiento = db.Establecimiento.FirstOrDefault(e => e.ID == idEstablecimiento);
            //establecimiento.Mails = db.Mail_Establecimiento.Where(m => m.Establecimiento_ID == idEstablecimiento).ToList<Mail_Establecimiento>();
            //establecimiento.Numeros = db.Numero_Establecimiento.Where(n => n.Establecimiento_ID == idEstablecimiento).ToList<Numero_Establecimiento>();

            return Ok(new EstablecimientoDTO(establecimiento));
        }

        // POST: api/Establecimiento
        [HttpPost()]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostEstablecimiento(Establecimiento establecimiento, [FromUri]int idCaballo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Establecimiento newEstablecimiento = new Establecimiento();
                newEstablecimiento.Nombre = establecimiento.Nombre;
                newEstablecimiento.Propietario = establecimiento.Propietario;
                newEstablecimiento.Ubicacion = establecimiento.Ubicacion;
                newEstablecimiento.DescUbicacion = establecimiento.DescUbicacion;

                db.Establecimiento.Add(newEstablecimiento);

                foreach (Mail_Establecimiento mail in establecimiento.Mails)
                {
                    mail.Establecimiento = newEstablecimiento;
                    mail.Tipo = new Tipo_Mail();
                    db.Mail_Establecimiento.Add(mail);
                }

                foreach (Numero_Establecimiento numero in establecimiento.Numeros)
                {
                    numero.Establecimiento = newEstablecimiento;
                    numero.Tipo = new Tipo_Numero();
                    db.Numero_Establecimiento.Add(numero);
                }

                Caballo caballo = db.Caballos.FirstOrDefault(c => c.ID == idCaballo);
                caballo.Establecimiento = newEstablecimiento;

                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                //return Content(HttpStatusCode.BadRequest, ex);
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Establecimiento/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstablecimiento(Establecimiento establecimiento, [FromUri]int idCaballo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Establecimiento establecimientoToUpdate = db.Caballos.FirstOrDefault(c => c.ID == idCaballo).Establecimiento;
                establecimientoToUpdate.Nombre = establecimiento.Nombre;
                establecimientoToUpdate.Propietario = establecimiento.Propietario;
                establecimientoToUpdate.DescUbicacion = establecimiento.DescUbicacion;
                establecimientoToUpdate.Ubicacion = establecimiento.Ubicacion;

                db.Mail_Establecimiento.RemoveRange(db.Mail_Establecimiento.Where(m => m.Establecimiento.ID == establecimientoToUpdate.ID));
                db.Numero_Establecimiento.RemoveRange(db.Numero_Establecimiento.Where(n => n.Establecimiento.ID == establecimientoToUpdate.ID));

                foreach (Mail_Establecimiento mail in establecimiento.Mails)
                {
                    mail.Establecimiento = establecimientoToUpdate;
                    mail.Tipo = new Tipo_Mail();
                    db.Mail_Establecimiento.Add(mail);
                }

                foreach (Numero_Establecimiento numero in establecimiento.Numeros)
                {
                    numero.Establecimiento = establecimientoToUpdate;
                    numero.Tipo = new Tipo_Numero();
                    db.Numero_Establecimiento.Add(numero);
                }

                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Establecimiento/5
        [Route("api/establecimiento/delete/{idEstablecimiento}")]
        [ResponseType(typeof(Establecimiento))]
        public IHttpActionResult DeleteEstablecimiento(int idEstablecimiento)
        {
            try
            {
                IQueryable<Caballo> caballos = db.Caballos.Where(c => c.Establecimiento.ID == idEstablecimiento);
                foreach (Caballo caballo in caballos)
                    caballo.Establecimiento = null;

                Establecimiento establecimiento = db.Establecimiento.FirstOrDefault(e => e.ID == idEstablecimiento);
                if (establecimiento == null)
                {
                    return NotFound();
                }

                db.Establecimiento.Remove(establecimiento);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}