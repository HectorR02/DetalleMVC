namespace Detalle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cotizaciones",
                c => new
                    {
                        CotizacionId = c.Int(nullable: false, identity: true),
                        Cliente = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Monto = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CotizacionId);
            
            CreateTable(
                "dbo.CotizacionDetalles",
                c => new
                    {
                        CotizacionDetalleId = c.Int(nullable: false, identity: true),
                        CotizacionId = c.Int(nullable: false),
                        ArticuloId = c.Int(nullable: false),
                        Articulo = c.String(),
                        Cantidad = c.Int(nullable: false),
                        PrecXund = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CotizacionDetalleId)
                .ForeignKey("dbo.Cotizaciones", t => t.CotizacionId, cascadeDelete: true)
                .Index(t => t.CotizacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CotizacionDetalles", "CotizacionId", "dbo.Cotizaciones");
            DropIndex("dbo.CotizacionDetalles", new[] { "CotizacionId" });
            DropTable("dbo.CotizacionDetalles");
            DropTable("dbo.Cotizaciones");
        }
    }
}
