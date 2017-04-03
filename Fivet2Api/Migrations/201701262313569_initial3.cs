namespace Fivet2Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Caballo", "NumeroFEI", c => c.Int());
            AlterColumn("dbo.Caballo", "NumeroFEN", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Caballo", "NumeroFEN", c => c.Int(nullable: false));
            AlterColumn("dbo.Caballo", "NumeroFEI", c => c.Int(nullable: false));
        }
    }
}
