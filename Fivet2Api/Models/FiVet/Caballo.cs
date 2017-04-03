using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fivet2Api.Models.FiVet
{
    public class Caballo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? FechaNacimiento { get; set; }
        public string NumeroChip { get; set; }
        public int? NumeroFEI { get; set; }
        public bool EstadoFEI { get; set; }
        public string Protector { get; set; }
        public string Embocadura { get; set; }
        public string ExtrasDeCabezada { get; set; }
        public bool? ADN { get; set; }
        public string NumeroId { get; set; }
        public int? NumeroFEN { get; set; }
        public bool EstadoFEN { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Pelaje Pelaje { get; set; }
        public virtual EstadoProvincia EstadoProvincia { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Propietario Propietario { get; set; }
        public virtual Pedigree Pedigree { get; set; }
        public virtual Criador Criador { get; set; }
        public virtual OtrasMarcas OtrasMarcas { get; set; }
        public virtual Establecimiento Establecimiento { get; set; }
        public string Alimentacion { get; set; }
        public virtual PersonaACargo PersonaACargo { get; set; }

        public virtual ICollection<Alerta> Alertas { get; set; }

        public Caballo()
        {
        }
    }

    public class CaballoDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NumeroChip { get; set; }
        public int? NumeroFEI { get; set; }
        public bool EstadoFEI { get; set; }
        public string Protector { get; set; }
        public string Embocadura { get; set; }
        public string ExtrasDeCabezada { get; set; }
        public string Agrupamiento { get; set; }
        public string NumeroId { get; set; }
        public int? NumeroFEN { get; set; }
        public bool EstadoFEN { get; set; }
        public bool? ADN { get; set; }
        public GeneroDTO Genero { get; set; }
        public PelajeDTO Pelaje { get; set; }
        public EstadoProvinciaDTO EstadoProvincia { get; set; }
        public GrupoDTO Grupo { get; set; }
        public PedigreeDTO Pedigree { get; set; }
        public PropietarioDTO Propietario { get; set; }
        public CriadorDTO Criador { get; set; }
        public OtrasMarcasDTO OtrasMarcas { get; set; }
        public EstablecimientoDTO Establecimiento { get; set; }
        public string Alimentacion { get; set; }
        public PersonaACargoDTO PersonaACargo { get; set; }
               

        public CaballoDTO() { }

        public CaballoDTO(Caballo x)
        {
            ID = x.ID;
            Nombre = x.Nombre;
            FechaNacimiento = x.FechaNacimiento;
            NumeroChip = x.NumeroChip;
            NumeroFEI = x.NumeroFEI;
            EstadoFEI = x.EstadoFEI;
            NumeroFEN = x.NumeroFEN;
            NumeroId = x.NumeroId;
            EstadoFEN = x.EstadoFEN;
            Protector = x.Protector;
            Embocadura = x.Embocadura;
            ExtrasDeCabezada = x.ExtrasDeCabezada;
            ADN = x.ADN;
            Genero = x.Genero != null ? new GeneroDTO() { ID = x.Genero.ID, Descripcion = x.Genero.Descripcion } : null;
            Pelaje = x.Pelaje != null ? new PelajeDTO() { ID = x.Pelaje.ID, Descripcion = x.Pelaje.Descripcion } : null;
            EstadoProvincia = x.EstadoProvincia != null ? new EstadoProvinciaDTO() { Id = x.EstadoProvincia.Id, Nombre = x.EstadoProvincia.Nombre, Pais = x.EstadoProvincia.Pais != null ? new PaisDTO() { ID = x.EstadoProvincia.Pais.ID, Descripcion = x.EstadoProvincia.Pais.Descripcion } : null } : null;
            Grupo = x.Grupo != null ? new GrupoDTO() { ID = x.Grupo.ID, Descripcion = x.Grupo.Descripcion } : null;
            Pedigree = x.Pedigree != null ? new PedigreeDTO()
            {
                ID = x.Pedigree.ID,
                Padre = x.Pedigree.Padre,
                Madre = x.Pedigree.Madre,
                Imagen = x.Pedigree.Imagen
            } : null;
            Propietario = x.Propietario != null ? new PropietarioDTO()
            {
                ID = x.Propietario.ID,
                Nombre = x.Propietario.Nombre,
                Apellido = x.Propietario.Apellido,
                Mail = x.Propietario.Mail,
                Celular = x.Propietario.Celular,
                FechaNacimiento = x.Propietario.FechaNacimiento,
                EstadoProvincia = x.EstadoProvincia != null ? new EstadoProvinciaDTO() { Id = x.EstadoProvincia.Id, Nombre = x.EstadoProvincia.Nombre, Pais = x.EstadoProvincia.Pais != null ? new PaisDTO() { ID = x.EstadoProvincia.Pais.ID, Descripcion = x.EstadoProvincia.Pais.Descripcion } : null } : null,
            } : null;
            Criador = x.Criador != null ? new CriadorDTO()
            {
                ID = x.Criador.ID,
                Nombre = x.Criador.Nombre,
                Pais = x.Criador.Pais != null ? new PaisDTO() { ID = x.Criador.Pais.ID, Descripcion = x.Criador.Pais.Descripcion } : null
            } : null;
            OtrasMarcas = x.OtrasMarcas != null ? new OtrasMarcasDTO() { ID = x.OtrasMarcas.ID, Descripcion = x.OtrasMarcas.Descripcion, Imagen = x.OtrasMarcas.Imagen } : null;
            Establecimiento = new EstablecimientoDTO();
            Alimentacion = x.Alimentacion;
            PersonaACargo = x.PersonaACargo != null ? new PersonaACargoDTO()
            {
                ID = x.PersonaACargo.ID,
                Nombre = x.PersonaACargo.Nombre,
                Mail = x.PersonaACargo.Mail,
                Telefono = x.PersonaACargo.Telefono
            } : null;
        }
    }
}