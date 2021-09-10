namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
