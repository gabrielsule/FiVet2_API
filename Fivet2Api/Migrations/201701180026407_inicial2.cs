namespace Fivet2Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alerta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        FechaNotificacion = c.DateTime(nullable: false),
                        HoraNotificacion = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Activa = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Caballo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumeroChip = c.String(),
                        NumeroFEI = c.Int(nullable: false),
                        EstadoFEI = c.Boolean(nullable: false),
                        Protector = c.String(),
                        Embocadura = c.String(),
                        ExtrasDeCabezada = c.String(),
                        ADN = c.Boolean(nullable: false),
                        NumeroId = c.String(),
                        NumeroFEN = c.Int(nullable: false),
                        EstadoFEN = c.Boolean(nullable: false),
                        Alimentacion = c.String(),
                        Criador_ID = c.Int(),
                        Establecimiento_ID = c.Int(),
                        EstadoProvincia_Id = c.Int(),
                        Genero_ID = c.Int(),
                        Grupo_ID = c.Int(),
                        OtrasMarcas_ID = c.Int(),
                        Pedigree_ID = c.Int(),
                        Pelaje_ID = c.Int(),
                        PersonaACargo_ID = c.Int(),
                        Propietario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Criador", t => t.Criador_ID)
                .ForeignKey("dbo.Establecimiento", t => t.Establecimiento_ID)
                .ForeignKey("dbo.EstadoProvincia", t => t.EstadoProvincia_Id)
                .ForeignKey("dbo.Genero", t => t.Genero_ID)
                .ForeignKey("dbo.Grupo", t => t.Grupo_ID)
                .ForeignKey("dbo.OtrasMarcas", t => t.OtrasMarcas_ID)
                .ForeignKey("dbo.Pedigree", t => t.Pedigree_ID)
                .ForeignKey("dbo.Pelaje", t => t.Pelaje_ID)
                .ForeignKey("dbo.PersonaACargo", t => t.PersonaACargo_ID)
                .ForeignKey("dbo.Propietario", t => t.Propietario_ID)
                .Index(t => t.Criador_ID)
                .Index(t => t.Establecimiento_ID)
                .Index(t => t.EstadoProvincia_Id)
                .Index(t => t.Genero_ID)
                .Index(t => t.Grupo_ID)
                .Index(t => t.OtrasMarcas_ID)
                .Index(t => t.Pedigree_ID)
                .Index(t => t.Pelaje_ID)
                .Index(t => t.PersonaACargo_ID)
                .Index(t => t.Propietario_ID);
            
            CreateTable(
                "dbo.Criador",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Pais_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pais", t => t.Pais_ID)
                .Index(t => t.Pais_ID);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EstadoProvincia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Pais_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.Pais_ID)
                .Index(t => t.Pais_ID);
            
            CreateTable(
                "dbo.Establecimiento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Propietario = c.String(),
                        Ubicacion = c.String(),
                        DescUbicacion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Mail_Establecimiento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MailDesc = c.String(),
                        Establecimiento_ID = c.Int(),
                        Tipo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Establecimiento", t => t.Establecimiento_ID)
                .ForeignKey("dbo.Tipo_Mail", t => t.Tipo_ID)
                .Index(t => t.Establecimiento_ID)
                .Index(t => t.Tipo_ID);
            
            CreateTable(
                "dbo.Tipo_Mail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Numero_Establecimiento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Establecimiento_ID = c.Int(),
                        Tipo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Establecimiento", t => t.Establecimiento_ID)
                .ForeignKey("dbo.Tipo_Numero", t => t.Tipo_ID)
                .Index(t => t.Establecimiento_ID)
                .Index(t => t.Tipo_ID);
            
            CreateTable(
                "dbo.Tipo_Numero",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OtrasMarcas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pedigree",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Padre = c.String(),
                        Madre = c.String(),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pelaje",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PersonaACargo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Propietario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Mail = c.String(),
                        Celular = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        EstadoProvincia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EstadoProvincia", t => t.EstadoProvincia_Id)
                .Index(t => t.EstadoProvincia_Id);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DiasPreviosaNotificar = c.Int(),
                        Alerta_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alerta", t => t.Alerta_ID)
                .Index(t => t.Alerta_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "Alerta_ID", "dbo.Alerta");
            DropForeignKey("dbo.Caballo", "Propietario_ID", "dbo.Propietario");
            DropForeignKey("dbo.Propietario", "EstadoProvincia_Id", "dbo.EstadoProvincia");
            DropForeignKey("dbo.Caballo", "PersonaACargo_ID", "dbo.PersonaACargo");
            DropForeignKey("dbo.Caballo", "Pelaje_ID", "dbo.Pelaje");
            DropForeignKey("dbo.Caballo", "Pedigree_ID", "dbo.Pedigree");
            DropForeignKey("dbo.Caballo", "OtrasMarcas_ID", "dbo.OtrasMarcas");
            DropForeignKey("dbo.Caballo", "Grupo_ID", "dbo.Grupo");
            DropForeignKey("dbo.Caballo", "Genero_ID", "dbo.Genero");
            DropForeignKey("dbo.Caballo", "EstadoProvincia_Id", "dbo.EstadoProvincia");
            DropForeignKey("dbo.Caballo", "Establecimiento_ID", "dbo.Establecimiento");
            DropForeignKey("dbo.Numero_Establecimiento", "Tipo_ID", "dbo.Tipo_Numero");
            DropForeignKey("dbo.Numero_Establecimiento", "Establecimiento_ID", "dbo.Establecimiento");
            DropForeignKey("dbo.Mail_Establecimiento", "Tipo_ID", "dbo.Tipo_Mail");
            DropForeignKey("dbo.Mail_Establecimiento", "Establecimiento_ID", "dbo.Establecimiento");
            DropForeignKey("dbo.Caballo", "Criador_ID", "dbo.Criador");
            DropForeignKey("dbo.Criador", "Pais_ID", "dbo.Pais");
            DropForeignKey("dbo.EstadoProvincia", "Pais_ID", "dbo.Pais");
            DropIndex("dbo.Evento", new[] { "Alerta_ID" });
            DropIndex("dbo.Propietario", new[] { "EstadoProvincia_Id" });
            DropIndex("dbo.Numero_Establecimiento", new[] { "Tipo_ID" });
            DropIndex("dbo.Numero_Establecimiento", new[] { "Establecimiento_ID" });
            DropIndex("dbo.Mail_Establecimiento", new[] { "Tipo_ID" });
            DropIndex("dbo.Mail_Establecimiento", new[] { "Establecimiento_ID" });
            DropIndex("dbo.EstadoProvincia", new[] { "Pais_ID" });
            DropIndex("dbo.Criador", new[] { "Pais_ID" });
            DropIndex("dbo.Caballo", new[] { "Propietario_ID" });
            DropIndex("dbo.Caballo", new[] { "PersonaACargo_ID" });
            DropIndex("dbo.Caballo", new[] { "Pelaje_ID" });
            DropIndex("dbo.Caballo", new[] { "Pedigree_ID" });
            DropIndex("dbo.Caballo", new[] { "OtrasMarcas_ID" });
            DropIndex("dbo.Caballo", new[] { "Grupo_ID" });
            DropIndex("dbo.Caballo", new[] { "Genero_ID" });
            DropIndex("dbo.Caballo", new[] { "EstadoProvincia_Id" });
            DropIndex("dbo.Caballo", new[] { "Establecimiento_ID" });
            DropIndex("dbo.Caballo", new[] { "Criador_ID" });
            DropTable("dbo.Evento");
            DropTable("dbo.Propietario");
            DropTable("dbo.PersonaACargo");
            DropTable("dbo.Pelaje");
            DropTable("dbo.Pedigree");
            DropTable("dbo.OtrasMarcas");
            DropTable("dbo.Grupo");
            DropTable("dbo.Genero");
            DropTable("dbo.Tipo_Numero");
            DropTable("dbo.Numero_Establecimiento");
            DropTable("dbo.Tipo_Mail");
            DropTable("dbo.Mail_Establecimiento");
            DropTable("dbo.Establecimiento");
            DropTable("dbo.EstadoProvincia");
            DropTable("dbo.Pais");
            DropTable("dbo.Criador");
            DropTable("dbo.Caballo");
            DropTable("dbo.Alerta");
        }
    }
}
