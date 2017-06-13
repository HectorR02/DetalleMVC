namespace Detalle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServArt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        ArticuloId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.Double(nullable: false),
                        Existencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticuloId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.Double(nullable: false),
                        Duracion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Servicios");
            DropTable("dbo.Articulos");
        }
    }
}
