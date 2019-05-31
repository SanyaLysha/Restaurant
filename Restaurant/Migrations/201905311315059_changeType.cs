namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeType : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BarOrders");
            DropPrimaryKey("dbo.KitchenOrders");
            AddColumn("dbo.BarOrders", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.KitchenOrders", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.BarOrders", "Id");
            AddPrimaryKey("dbo.KitchenOrders", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.KitchenOrders");
            DropPrimaryKey("dbo.BarOrders");
            DropColumn("dbo.KitchenOrders", "Id");
            DropColumn("dbo.BarOrders", "Id");
            AddPrimaryKey("dbo.KitchenOrders", new[] { "OrderId", "DishId" });
            AddPrimaryKey("dbo.BarOrders", new[] { "OrderId", "DrinkId" });
        }
    }
}
