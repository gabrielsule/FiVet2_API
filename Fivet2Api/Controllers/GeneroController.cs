using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fivet2Api.Controllers
{
    public class GeneroController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Genero
        public IQueryable<Genero> GetGeneroes()
        {
            return db.Generos.ToList().AsQueryable();
        }

        // GET: api/Genero/5
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> GetGenero(int id)
        {
            Genero genero = await db.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        // PUT: api/Genero/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGenero(int id, Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genero.ID)
            {
                return BadRequest();
            }

            db.Entry(genero).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
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

        // POST: api/Genero
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> PostGenero(Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Generos.Add(genero);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = genero.ID }, genero);
        }

        // DELETE: api/Genero/5
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> DeleteGenero(int id)
        {
            Genero genero = await db.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            db.Generos.Remove(genero);
            await db.SaveChangesAsync();

            return Ok(genero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeneroExists(int id)
        {
            return db.Generos.Count(e => e.ID == id) > 0;
        }
    }
}