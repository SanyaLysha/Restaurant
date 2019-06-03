namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Paid", c => c.Boolean(nullable: false,defaultValue: true));
            AddColumn("dbo.Orders", "TableId", c => c.Int(nullable: false,defaultValue: new Random().Next(1,14)));
            CreateIndex("dbo.Orders", "TableId");
            AddForeignKey("dbo.Orders", "TableId", "dbo.Tables", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TableId", "dbo.Tables");
            DropIndex("dbo.Orders", new[] { "TableId" });
            DropColumn("dbo.Orders", "TableId");
            DropColumn("dbo.Orders", "Paid");
        }
    }
}
