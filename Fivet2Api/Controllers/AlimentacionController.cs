using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Fivet2Api.Controllers
{
    public class AlimentacionController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Alimentacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Alimentacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Alimentacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Alimentacion/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]string alimentacion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Caballo caballoToChange = db.Caballos.FirstOrDefault(c => c.ID == id);
                if (caballoToChange == null)
                    return NotFound();

                db.Entry(caballoToChange).State = EntityState.Modified;
                caballoToChange.Alimentacion = alimentacion;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
                throw ex;
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/Alimentacion/5
        public void Delete(int id)
        {
        }
    }
}
