namespace Fivet2Api.Migrations
{
    using Models.FiVet;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fivet2Api.Models.Fivet2ApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Fivet2Api.Models.Fivet2ApiContext context)
        {

            var otrasMarcas = new OtrasMarcas() { ID = 1, Descripcion = "Ota marca", Imagen = "URL" };
            var criador = new Criador() { ID = 1, Nombre = "Criador" };
            var propietario = new Propietario() { ID = 1, Apellido = "Apellido1", Celular = "5555", FechaNacimiento = DateTime.Today, Mail = "algo@gmail.com", Nombre = "Propietario1" };
            var pedigree = new Pedigree() { ID = 1, Imagen = "url", Madre = "madre", Padre = "padre" };
            var masculino = new Genero { ID = 1, Descripcion = "Masculino" };
            context.Generos.AddOrUpdate(new Genero[] { masculino, new Genero { ID = 2, Descripcion = "Femenino" }, new Genero { ID = 3, Descripcion = "Otro" } });

            var argentina = new Pais { ID = 1, Descripcion = "Argentina" };
            criador.Pais = argentina;
            var estado1 = new EstadoProvincia { Id = 1, Nombre = "Buenos Aires" };
            propietario.EstadoProvincia = estado1;
            var estado2 = new EstadoProvincia { Id = 2, Nombre = "Cordova" };

            argentina.EstadosProvincias.Add(estado1);
            argentina.EstadosProvincias.Add(estado2);
            context.Paises.AddOrUpdate(new Pais[] { argentina });

            var pelaje = new Pelaje { ID = 1, Descripcion = "pelaje1" };
            context.Pelajes.AddOrUpdate(new Pelaje[] { pelaje });
            context.EstadosProvincias.AddOrUpdate(new EstadoProvincia[] { estado1, estado2 });

            context.OtrasMarcas.AddOrUpdate(new OtrasMarcas[] { otrasMarcas });
            context.Criadores.AddOrUpdate(new Criador[] { criador });
            context.Propietarios.AddOrUpdate(new Propietario[] { propietario });
            context.Pedigrees.AddOrUpdate(new Pedigree[] { pedigree });
            var grupo = new Grupo { ID = 1, Descripcion = "Grupo 1" };

            var caballo = new Caballo
            {
                ID = 1,
                Establecimiento = null,
                EstadoFEI = true,
                Embocadura = "Embocadura",
                ExtrasDeCabezada = "ExtrasDeCabezada",
                FechaNacimiento = new DateTime().Date,
                Genero = masculino,
                Nombre = "Caballo1",
                NumeroChip = "1",
                NumeroFEI = 1,
                Protector = "Protector",
                ADN = false,
                EstadoFEN = false,
                NumeroFEN = 987,
                NumeroId = "9",
                Pelaje = pelaje,
                EstadoProvincia = estado1,
                Criador = criador,
                Propietario = propietario,
                OtrasMarcas = otrasMarcas,
                Pedigree = pedigree,
                Grupo = grupo
            };
            context.Caballos.AddOrUpdate(new Caballo[] { caballo });
            grupo.Caballos.Add(caballo);
            context.Grupos.AddOrUpdate(new Grupo[] { grupo });
            context.SaveChanges();
        }
    }
}
