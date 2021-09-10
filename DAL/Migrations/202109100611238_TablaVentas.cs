namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaVentas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        IdDetalleVenta = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        IdVenta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleVenta)
                .ForeignKey("dbo.Ventas", t => t.IdVenta, cascadeDelete: true)
                .Index(t => t.IdVenta);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        IdVenta = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenta)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleVentas", "IdVenta", "dbo.Ventas");
            DropIndex("dbo.Ventas", new[] { "IdProducto" });
            DropIndex("dbo.DetalleVentas", new[] { "IdVenta" });
            DropTable("dbo.Ventas");
            DropTable("dbo.DetalleVentas");
        }
    }
}
