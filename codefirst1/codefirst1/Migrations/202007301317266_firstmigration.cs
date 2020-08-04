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
                .ForeignKey("dbo.T_CategoriaProjectItem", t => t.ID_CategoriaProjectItem, cascadeDelete: true)
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
                        ID_Risorsa = c.Int(nullable: false, identity: true),
                        MatricolaRisorsa = c.String(),
                        Cognome = c.String(),
                        Nome = c.String(),
                        Mail = c.String(),
                        Telefono = c.String(),
                        Cellulare = c.String(),
                    })
                .PrimaryKey(t => t.ID_Risorsa);
            
            CreateTable(
                "dbo.E_Task",
                c => new
                    {
                        ID_Task = c.Int(nullable: false, identity: true),
                        Titolo = c.String(),
                        Descrizione = c.String(),
                        ID_ParentTask = c.Int(),
                        DataInserimento = c.DateTime(nullable: false),
                        DataUltimoAggiornamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Task)
                .ForeignKey("dbo.E_Task", t => t.ID_ParentTask)
                .Index(t => t.ID_ParentTask);
            
            CreateTable(
                "dbo.E_TaskE_Risorsa",
                c => new
                    {
                        E_Task_ID_Task = c.Int(nullable: false),
                        E_Risorsa_ID_Risorsa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.E_Task_ID_Task, t.E_Risorsa_ID_Risorsa })
                .ForeignKey("dbo.E_Task", t => t.E_Task_ID_Task, cascadeDelete: true)
                .ForeignKey("dbo.E_Risorsa", t => t.E_Risorsa_ID_Risorsa, cascadeDelete: true)
                .Index(t => t.E_Task_ID_Task)
                .Index(t => t.E_Risorsa_ID_Risorsa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.E_Task", "ID_ParentTask", "dbo.E_Task");
            DropForeignKey("dbo.E_TaskE_Risorsa", "E_Risorsa_ID_Risorsa", "dbo.E_Risorsa");
            DropForeignKey("dbo.E_TaskE_Risorsa", "E_Task_ID_Task", "dbo.E_Task");
            DropForeignKey("dbo.E_ProjectItem", "ID_CategoriaProjectItem", "dbo.T_CategoriaProjectItem");
            DropIndex("dbo.E_TaskE_Risorsa", new[] { "E_Risorsa_ID_Risorsa" });
            DropIndex("dbo.E_TaskE_Risorsa", new[] { "E_Task_ID_Task" });
            DropIndex("dbo.E_Task", new[] { "ID_ParentTask" });
            DropIndex("dbo.E_ProjectItem", new[] { "ID_CategoriaProjectItem" });
            DropTable("dbo.E_TaskE_Risorsa");
            DropTable("dbo.E_Task");
            DropTable("dbo.E_Risorsa");
            DropTable("dbo.T_CategoriaProjectItem");
            DropTable("dbo.E_ProjectItem");
        }
    }
}
