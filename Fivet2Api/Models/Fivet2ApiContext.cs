using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fivet2Api.Models
{
    public class Fivet2ApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Fivet2ApiContext() : base("name=Fivet2ApiContext")
        {
            //Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Caballo> Caballos { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.EstadoProvincia> EstadosProvincias { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Genero> Generos { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Grupo> Grupos { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Pais> Paises { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Pelaje> Pelajes { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Propietario> Propietarios { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.OtrasMarcas> OtrasMarcas { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Criador> Criadores { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Pedigree> Pedigrees { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Establecimiento> Establecimiento { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Mail_Establecimiento> Mail_Establecimiento { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Numero_Establecimiento> Numero_Establecimiento { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.PersonaACargo> PersonaACargo { get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Alerta> Alertas{ get; set; }
        public System.Data.Entity.DbSet<Fivet2Api.Models.FiVet.Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
