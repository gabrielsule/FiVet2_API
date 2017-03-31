namespace Fivet2Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Caballo", "FechaNacimiento", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Caballo", "ADN", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Caballo", "ADN", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Caballo", "FechaNacimiento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
