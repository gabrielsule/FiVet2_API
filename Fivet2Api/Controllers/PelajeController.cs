using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fivet2Api.Controllers
{
    public class PelajeController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Pelaje
        public IQueryable<Pelaje> GetPelajes()
        {
            return db.Pelajes.ToList().AsQueryable();
        }

        // GET: api/Pelaje/5
        [ResponseType(typeof(Pelaje))]
        public async Task<IHttpActionResult> GetPelaje(int id)
        {
            Pelaje pelaje = await db.Pelajes.FindAsync(id);
            if (pelaje == null)
            {
                return NotFound();
            }

            return Ok(pelaje);
        }
    }
}
