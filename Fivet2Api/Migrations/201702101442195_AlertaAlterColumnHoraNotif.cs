namespace Fivet2Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertaAlterColumnHoraNotif : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alerta", "HoraNotificacion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alerta", "HoraNotificacion", c => c.Int(nullable: false));
        }
    }
}
