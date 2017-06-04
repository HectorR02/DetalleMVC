namespace Detalle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitiesModify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CotizacionDetalles", "CotizacionId", "dbo.Cotizaciones");
            DropIndex("dbo.CotizacionDetalles", new[] { "CotizacionId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CotizacionDetalles", "CotizacionId");
            AddForeignKey("dbo.CotizacionDetalles", "CotizacionId", "dbo.Cotizaciones", "CotizacionId", cascadeDelete: true);
        }
    }
}
