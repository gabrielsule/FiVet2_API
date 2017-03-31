namespace Fivet2Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertaCaballo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alerta", "Caballo_ID", c => c.Int());
            CreateIndex("dbo.Alerta", "Caballo_ID");
            AddForeignKey("dbo.Alerta", "Caballo_ID", "dbo.Caballo", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alerta", "Caballo_ID", "dbo.Caballo");
            DropIndex("dbo.Alerta", new[] { "Caballo_ID" });
            DropColumn("dbo.Alerta", "Caballo_ID");
        }
    }
}
