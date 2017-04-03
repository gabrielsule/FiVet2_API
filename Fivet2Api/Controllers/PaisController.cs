using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;

namespace Fivet2Api.Controllers
{
    public class PaisController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Pais
        public IQueryable<Pais> GetPaises()
        {
            return db.Paises.ToList().AsQueryable();
        }

        // GET: api/Pais/5
        [ResponseType(typeof(Pais))]
        public async Task<IHttpActionResult> GetPais(int id)
        {
            Pais pais = await db.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            return Ok(pais);
        }

        // PUT: api/Pais/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPais(int id, Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pais.ID)
            {
                return BadRequest();
            }

            db.Entry(pais).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Pais
        [ResponseType(typeof(Pais))]
        public async Task<IHttpActionResult> PostPais(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paises.Add(pais);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pais.ID }, pais);
        }

        // DELETE: api/Pais/5
        [ResponseType(typeof(Pais))]
        public async Task<IHttpActionResult> DeletePais(int id)
        {
            Pais pais = await db.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            db.Paises.Remove(pais);
            await db.SaveChangesAsync();

            return Ok(pais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaisExists(int id)
        {
            return db.Paises.Count(e => e.ID == id) > 0;
        }
    }
}