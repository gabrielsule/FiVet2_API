using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fivet2Api.Controllers
{
    public class CriadorController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Criador
        public IQueryable<Criador> GetCriadores()
        {
            return db.Criadores.ToList().AsQueryable();
        }

        // GET: api/Criador/5
        [ResponseType(typeof(Pelaje))]
        public async Task<IHttpActionResult> GetCriador(int id)
        {
            Criador criador = await db.Criadores.FindAsync(id);
            if (criador == null)
            {
                return NotFound();
            }

            return Ok(criador);
        }
    }
}
