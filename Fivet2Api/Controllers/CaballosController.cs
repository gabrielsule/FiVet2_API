using Fivet2Api.Models;
using Fivet2Api.Models.FiVet;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fivet2Api.Controllers
{
    public class CaballosController : ApiController
    {
        private Fivet2ApiContext db = new Fivet2ApiContext();

        // GET: api/Caballos
        public IQueryable<CaballoDTO> GetCaballos(string name = "", int limit = 0, int offset = 0)
        {
            IQueryable<Caballo> caballos;

            try
            {
                if (name.Equals(string.Empty))
                    return db.Caballos
                        .Select(caballo => new CaballoDTO
                        {
                            ID = caballo.ID,
                            Nombre = caballo.Nombre,
                            FechaNacimiento = caballo.FechaNacimiento != null ? caballo.FechaNacimiento : null,
                            NumeroChip = caballo.NumeroChip,
                            NumeroFEI = caballo.NumeroFEI,
                            EstadoFEI = caballo.EstadoFEI,
                            NumeroFEN = caballo.NumeroFEN,
                            NumeroId = caballo.NumeroId,
                            EstadoFEN = caballo.EstadoFEN,
                            Protector = caballo.Protector,
                            Embocadura = caballo.Embocadura,
                            ExtrasDeCabezada = caballo.ExtrasDeCabezada,
                            ADN = caballo.ADN,
                            Genero = caballo.Genero != null ? new GeneroDTO() { ID = caballo.Genero.ID, Descripcion = caballo.Genero.Descripcion } : null,
                            Pelaje = caballo.Pelaje != null ? new PelajeDTO() { ID = caballo.Pelaje.ID, Descripcion = caballo.Pelaje.Descripcion } : null,
                            EstadoProvincia = caballo.EstadoProvincia != null ? new EstadoProvinciaDTO() { Id = caballo.EstadoProvincia.Id, Nombre = caballo.EstadoProvincia.Nombre, Pais = caballo.EstadoProvincia.Pais != null ? new PaisDTO() { ID = caballo.EstadoProvincia.Pais.ID, Descripcion = caballo.EstadoProvincia.Pais.Descripcion } : null } : null,
                            Grupo = caballo.Grupo != null ? new GrupoDTO() { ID = caballo.Grupo.ID, Descripcion = caballo.Grupo.Descripcion } : null,
                            Pedigree = caballo.Pedigree != null ? new PedigreeDTO()
                            {
                                ID = caballo.Pedigree.ID,
                                Padre = caballo.Pedigree.Padre,
                                Madre = caballo.Pedigree.Madre,
                                Imagen = caballo.Pedigree.Imagen
                            } : null,
                            Propietario = caballo.Propietario != null ? new PropietarioDTO()
                            {
                                ID = caballo.Propietario.ID,
                                Nombre = caballo.Propietario.Nombre,
                                Apellido = caballo.Propietario.Apellido,
                                Mail = caballo.Propietario.Mail,
                                Celular = caballo.Propietario.Celular,
                                FechaNacimiento = caballo.Propietario.FechaNacimiento,
                                EstadoProvincia = caballo.EstadoProvincia != null ? new EstadoProvinciaDTO() { Id = caballo.EstadoProvincia.Id, Nombre = caballo.EstadoProvincia.Nombre, Pais = caballo.EstadoProvincia.Pais != null ? new PaisDTO() { ID = caballo.EstadoProvincia.Pais.ID, Descripcion = caballo.EstadoProvincia.Pais.Descripcion } : null } : null,
                            } : null,
                            Criador = caballo.Criador != null ? new CriadorDTO()
                            {
                                ID = caballo.Criador.ID,
                                Nombre = caballo.Criador.Nombre,
                                Pais = caballo.Criador.Pais != null ? new PaisDTO() { ID = caballo.Criador.Pais.ID, Descripcion = caballo.Criador.Pais.Descripcion } : null
                            } : null,
                            OtrasMarcas = caballo.OtrasMarcas != null ? new OtrasMarcasDTO() { ID = caballo.OtrasMarcas.ID, Descripcion = caballo.OtrasMarcas.Descripcion, Imagen = caballo.OtrasMarcas.Imagen } : null,
                            Establecimiento = new EstablecimientoDTO(),
                            Alimentacion = caballo.Alimentacion,
                            PersonaACargo = caballo.PersonaACargo != null ? new PersonaACargoDTO()

                            {
                                ID = caballo.PersonaACargo.ID,
                                Nombre = caballo.PersonaACargo.Nombre,
                                Mail = caballo.PersonaACargo.Mail,
                                Telefono = caballo.PersonaACargo.Telefono
                            } : null

                        }).AsQueryable<CaballoDTO>();
                else
                    caballos = db.Caballos.Where(x => x.Nombre.Contains(name));

                if (offset != 0)
                    caballos.Skip(offset);
                if (limit != 0)
                    caballos.Take(offset);

                return caballos
                    .Select(caballo => new CaballoDTO
                    {
                        ID = caballo.ID,
                        Nombre = caballo.Nombre,
                        FechaNacimiento = caballo.FechaNacimiento != null ? caballo.FechaNacimiento : null,
                        NumeroChip = caballo.NumeroChip,
                        NumeroFEI = caballo.NumeroFEI,
                        EstadoFEI = caballo.EstadoFEI,
                        NumeroFEN = caballo.NumeroFEN,
                        NumeroId = caballo.NumeroId,
                        EstadoFEN = caballo.EstadoFEN,
                        Protector = caballo.Protector,
                        Embocadura = caballo.Embocadura,
                        ExtrasDeCabezada = caballo.ExtrasDeCabezada,
                        ADN = caballo.ADN,
                        Genero = caballo.Genero != null ? new GeneroDTO() { ID = caballo.Genero.ID, Descripcion = caballo.Genero.Descripcion } : null,
                        Pelaje = caballo.Pelaje != null ? new PelajeDTO() { ID = caballo.Pelaje.ID, Descripcion = caballo.Pelaje.Descripcion } : null,
                        EstadoProvincia = caballo.EstadoProvincia != null ? new EstadoProvinciaDTO() { Id = caballo.EstadoProvincia.Id, Nombre = caballo.EstadoProvincia.Nombre, Pais = caballo.EstadoProvincia.Pais != null ? new PaisDTO() { ID = caballo.EstadoProvincia.Pais.ID, Descripcion = caballo.EstadoProvincia.Pais.Descripcion } : null } : null,
                        Grupo = caballo.Grupo != null ? new GrupoDTO() { ID = caballo.Grupo.ID, Descripcion = caballo.Grupo.Descripcion } : null,
                        Pedigree = caballo.Pedigree != null ? new PedigreeDTO()
                        {
                            ID = caballo.Pedigree.ID,
                            Padre = caballo.Pedigree.Padre,
                            Madre = caballo.Pedigree.Madre,
                            Imagen = caballo.Pedigree.Imagen
                        } : null,
                        Propietario = caballo.Propietario != null ? new PropietarioDTO()
                        {
                            ID = caballo.Propietario.ID,
                            Nombre = caballo.Propietario.Nombre,
                            Apellido = caballo.Propietario.Apellido,
                            Mail = caballo.Propietario.Mail,
                            Celular = caballo.Propietario.Celular,
                            FechaNacimiento = caballo.Propietario.FechaNacimiento,
                            EstadoProvincia = caballo.EstadoProvincia != null ? new EstadoProvinciaDTO() { Id = caballo.EstadoProvincia.Id, Nombre = caballo.EstadoProvincia.Nombre, Pais = caballo.EstadoProvincia.Pais != null ? new PaisDTO() { ID = caballo.EstadoProvincia.Pais.ID, Descripcion = caballo.EstadoProvincia.Pais.Descripcion } : null } : null,
                        } : null,
                        Criador = caballo.Criador != null ? new CriadorDTO()
                        {
                            ID = caballo.Criador.ID,
                            Nombre = caballo.Criador.Nombre,
                            Pais = caballo.Criador.Pais != null ? new PaisDTO() { ID = caballo.Criador.Pais.ID, Descripcion = caballo.Criador.Pais.Descripcion } : null
                        } : null,
                        OtrasMarcas = caballo.OtrasMarcas != null ? new OtrasMarcasDTO() { ID = caballo.OtrasMarcas.ID, Descripcion = caballo.OtrasMarcas.Descripcion, Imagen = caballo.OtrasMarcas.Imagen } : null,
                        Establecimiento = new EstablecimientoDTO(),
                        Alimentacion = caballo.Alimentacion,
                        PersonaACargo = caballo.PersonaACargo != null ? new PersonaACargoDTO()
                        {
                            ID = caballo.PersonaACargo.ID,
                            Nombre = caballo.PersonaACargo.Nombre,
                            Mail = caballo.PersonaACargo.Mail,
                            Telefono = caballo.PersonaACargo.Telefono
                        } : null
                    }).AsQueryable<CaballoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Caballos/5
        [ResponseType(typeof(CaballoDTO))]
        public IHttpActionResult GetCaballo(int id)
        {
            Caballo caballo = db.Caballos.FirstOrDefault(c => c.ID == id);
            if (caballo == null)
            {
                return NotFound();
            }
            new CaballoDTO(caballo);
            return Ok(new CaballoDTO(caballo));
        }

        // PUT: api/Caballos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCaballo(int id, CaballoSerial caballo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Caballo caballoToChange = db.Caballos.FirstOrDefault(c => c.ID == id);
                if (caballoToChange == null)
                    return NotFound();

                db.Entry(caballoToChange).State = EntityState.Modified;

                // Pedigree
                Pedigree newPedigree;
                if (!String.IsNullOrEmpty(caballo.Padre) || !String.IsNullOrEmpty(caballo.Madre))
                {
                    if (caballoToChange.Pedigree != null)
                    {
                        caballoToChange.Pedigree.Padre = caballo.Padre;
                        caballoToChange.Pedigree.Madre = caballo.Madre;
                    }
                    else
                    {
                        newPedigree = new Pedigree();
                        newPedigree.Padre = caballo.Padre;
                        newPedigree.Madre = caballo.Madre;
                        caballoToChange.Pedigree = newPedigree;
                    }
                }

                caballoToChange.Nombre = caballo.Nombre;
                caballoToChange.Genero = db.Generos.FirstOrDefault(g => g.ID == caballo.Genero);
                caballoToChange.Pelaje = db.Pelajes.FirstOrDefault(p => p.ID == caballo.Pelaje);
                caballoToChange.FechaNacimiento = caballo.FechaNacimiento;

                caballoToChange.Pedigree.Padre = caballo.Padre;
                caballoToChange.Pedigree.Madre = caballo.Madre;
                caballoToChange.ADN = caballo.ADN;
                caballoToChange.NumeroChip = caballo.NumeroChip;
                caballoToChange.NumeroId = caballo.NumeroId;
                caballoToChange.Criador = db.Criadores.FirstOrDefault(c => c.ID == caballo.Criador);

                //db.SaveChanges();
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
                throw ex;
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Caballos
        [ResponseType(typeof(CaballoSerial))]
        public async Task<IHttpActionResult> PostCaballo(CaballoSerial caballo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Caballo newCaballo = new Caballo();
                // Campos obligatorios
                newCaballo.Nombre = caballo.Nombre;
                newCaballo.Genero = db.Generos.FirstOrDefault(g => g.ID == caballo.Genero);
                newCaballo.Pelaje = db.Pelajes.FirstOrDefault(p => p.ID == caballo.Pelaje);

                // Pedigree
                Pedigree newPedigree;
                if (!String.IsNullOrEmpty(caballo.Padre) || !String.IsNullOrEmpty(caballo.Madre))
                {
                    newPedigree = new Pedigree();
                    newPedigree.Padre = caballo.Padre;
                    newPedigree.Madre = caballo.Madre;
                    newCaballo.Pedigree = newPedigree;
                }
                else
                    newCaballo.Pedigree = null;
                
                // Resto de campos

                // El grupo por default es nulo.
                newCaballo.Grupo = null;

                newCaballo.ADN = caballo.ADN;
                newCaballo.Criador = (caballo.Criador != null) ? db.Criadores.FirstOrDefault(c => c.ID == caballo.Criador) : null;
                newCaballo.NumeroChip = caballo.NumeroChip;
                newCaballo.NumeroId = caballo.NumeroId;
                newCaballo.EstadoProvincia = (caballo.EstadoProvincia != null) ? db.EstadosProvincias.FirstOrDefault(g => g.Id == caballo.EstadoProvincia) : null;
                newCaballo.FechaNacimiento = (caballo.FechaNacimiento != null) ? (DateTime?)caballo.FechaNacimiento.Value.AddDays(1) : null;
                newCaballo.Propietario = (caballo.Propietario != null) ? db.Propietarios.FirstOrDefault(p => p.ID == caballo.Propietario) : null;
                newCaballo.Protector = caballo.Protector;
                newCaballo.Embocadura = caballo.Embocadura;
                newCaballo.ExtrasDeCabezada = caballo.ExtrasDeCabezada;

                db.Caballos.Add(newCaballo);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = newCaballo.ID }, newCaballo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Caballos/5
        [ResponseType(typeof(Caballo))]
        public async Task<IHttpActionResult> DeleteCaballo(int id)
        {
            Caballo caballo = await db.Caballos.FindAsync(id);
            if (caballo == null)
            {
                return NotFound();
            }

            db.Caballos.Remove(caballo);
            await db.SaveChangesAsync();

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

        private bool CaballoExists(int id)
        {
            return db.Caballos.Count(e => e.ID == id) > 0;
        }
    }
}