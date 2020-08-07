namespace codefirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.E_ProjectItem",
                c => new
                    {
                        ID_ProjectItem = c.Int(nullable: false, identity: true),
                        Titolo = c.String(),
                        Descrizione = c.String(),
                        ID_CategoriaProjectItem = c.Int(nullable: false),
                        DataInserimento = c.DateTime(nullable: false),
                        DataUltimoAggiornamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_ProjectItem)
                .ForeignKey("dbo.T_CategoriaProjectItem", t => t.ID_CategoriaProjectItem)
                .Index(t => t.ID_CategoriaProjectItem);
            
            CreateTable(
                "dbo.T_CategoriaProjectItem",
                c => new
                    {
                        ID_CategoriaProjectItem = c.Int(nullable: false, identity: true),
                        Nome = c.Binary(),
                        Descrizione = c.String(),
                        DataInserimento = c.DateTime(nullable: false),
                        DataUltimaModifica = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_CategoriaProjectItem);
            
            CreateTable(
                "dbo.E_Risorsa",
                c => new
                    {
                        ID_Risorsa = c.Int(nullable: false),
                        MatricolaRisorsa = c.String(nullable: false, maxLength: 10),
                        Cognome = c.String(maxLength: 100),
                        Nome = c.String(maxLength: 100),
                        Mail = c.String(maxLength: 100),
                        Telefono = c.String(maxLength: 50),
                        Cellulare = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_Risorsa);
            
            CreateTable(
                "dbo.E_Task",
                c => new
                    {
                        ID_Task = c.Int(nullable: false, identity: true),
                        Titolo = c.String(nullable: false, maxLength: 200),
                        Descrizione = c.String(),
                        ID_ParentTask = c.Int(),
                        DataInserimento = c.DateTime(nullable: false),
                        DataUltimoAggiornamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Task)
                .ForeignKey("dbo.E_Task", t => t.ID_ParentTask)
                .Index(t => t.ID_ParentTask);
            
            CreateTable(
                "dbo.A_Risorsa_Task",
                c => new
                    {
                        ID_RISORSA = c.Int(nullable: false),
                        ID_TASK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID_RISORSA, t.ID_TASK })
                .ForeignKey("dbo.E_Risorsa", t => t.ID_RISORSA, cascadeDelete: true)
                .ForeignKey("dbo.E_Task", t => t.ID_TASK, cascadeDelete: true)
                .Index(t => t.ID_RISORSA)
                .Index(t => t.ID_TASK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.A_Risorsa_Task", "ID_TASK", "dbo.E_Task");
            DropForeignKey("dbo.A_Risorsa_Task", "ID_RISORSA", "dbo.E_Risorsa");
            DropForeignKey("dbo.E_Task", "ID_ParentTask", "dbo.E_Task");
            DropForeignKey("dbo.E_ProjectItem", "ID_CategoriaProjectItem", "dbo.T_CategoriaProjectItem");
            DropIndex("dbo.A_Risorsa_Task", new[] { "ID_TASK" });
            DropIndex("dbo.A_Risorsa_Task", new[] { "ID_RISORSA" });
            DropIndex("dbo.E_Task", new[] { "ID_ParentTask" });
            DropIndex("dbo.E_ProjectItem", new[] { "ID_CategoriaProjectItem" });
            DropTable("dbo.A_Risorsa_Task");
            DropTable("dbo.E_Task");
            DropTable("dbo.E_Risorsa");
            DropTable("dbo.T_CategoriaProjectItem");
            DropTable("dbo.E_ProjectItem");
        }
    }
}
