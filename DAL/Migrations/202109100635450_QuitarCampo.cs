namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitarCampo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ventas", new[] { "IdProducto" });
            CreateIndex("dbo.DetalleVentas", "IdProducto");
            DropColumn("dbo.Ventas", "IdProducto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ventas", "IdProducto", c => c.Int(nullable: false));
            DropIndex("dbo.DetalleVentas", new[] { "IdProducto" });
            CreateIndex("dbo.Ventas", "IdProducto");
        }
    }
}
