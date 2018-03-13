namespace FilRouge.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilRougeDBContextv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Difficulties", "TauxJunior", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Difficulties", "TauxConfirmed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Difficulties", "TauxExpert", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Difficulties", "TauxExpert");
            DropColumn("dbo.Difficulties", "TauxConfirmed");
            DropColumn("dbo.Difficulties", "TauxJunior");
        }
    }
}
