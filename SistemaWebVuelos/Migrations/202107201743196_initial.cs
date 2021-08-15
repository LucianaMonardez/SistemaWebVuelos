namespace SistemaWebVuelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vuelo",
                c => new
                    {
                        idVuelo = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        Destino = c.String(nullable: false, maxLength: 50),
                        Origen = c.String(nullable: false, maxLength: 50),
                        Matricula = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.idVuelo)
                .Index(t => t.Matricula, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vuelo", new[] { "Matricula" });
            DropTable("dbo.Vuelo");
        }
    }
}
