namespace CerquinT3Tarjeta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gasto",
                c => new
                    {
                        IdGasto = c.Int(nullable: false, identity: true),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        TarjetaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdGasto)
                .ForeignKey("dbo.Tarjeta", t => t.TarjetaId, cascadeDelete: true)
                .Index(t => t.TarjetaId);
            
            CreateTable(
                "dbo.Tarjeta",
                c => new
                    {
                        IdTarjeta = c.Int(nullable: false, identity: true),
                        EntidadFinanciera = c.String(),
                        NroTarjeta = c.String(),
                        MesVencimiento = c.Int(nullable: false),
                        AnoVencimiento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTarjeta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "TarjetaId", "dbo.Tarjeta");
            DropIndex("dbo.Gasto", new[] { "TarjetaId" });
            DropTable("dbo.Tarjeta");
            DropTable("dbo.Gasto");
        }
    }
}
