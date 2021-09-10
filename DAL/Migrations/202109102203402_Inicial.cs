namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.IdVenta, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdVenta);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        IdVenta = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleVentas", "IdVenta", "dbo.Ventas");
            DropForeignKey("dbo.DetalleVentas", "IdProducto", "dbo.Productos");
            DropIndex("dbo.DetalleVentas", new[] { "IdVenta" });
            DropIndex("dbo.DetalleVentas", new[] { "IdProducto" });
            DropTable("dbo.Ventas");
            DropTable("dbo.Productos");
            DropTable("dbo.DetalleVentas");
        }
    }
}
