namespace PsiSeniorGestaoPessoas.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiroMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordenacao",
                c => new
                    {
                        CoordenacaoId = c.String(nullable: false, maxLength: 200, unicode: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        CaixaPostal = c.String(maxLength: 255, unicode: false),
                        Coordenador_Matricula = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.CoordenacaoId)
                .ForeignKey("dbo.Empregado", t => t.Coordenador_Matricula)
                .Index(t => t.Coordenador_Matricula);
            
            CreateTable(
                "dbo.Empregado",
                c => new
                    {
                        Matricula = c.String(nullable: false, maxLength: 200, unicode: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        Coordenacao_CoordenacaoId = c.String(maxLength: 200, unicode: false),
                        Coordenacao_CoordenacaoId1 = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Matricula)
                .ForeignKey("dbo.Coordenacao", t => t.Coordenacao_CoordenacaoId)
                .ForeignKey("dbo.Coordenacao", t => t.Coordenacao_CoordenacaoId1)
                .Index(t => t.Coordenacao_CoordenacaoId)
                .Index(t => t.Coordenacao_CoordenacaoId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empregado", "Coordenacao_CoordenacaoId1", "dbo.Coordenacao");
            DropForeignKey("dbo.Coordenacao", "Coordenador_Matricula", "dbo.Empregado");
            DropForeignKey("dbo.Empregado", "Coordenacao_CoordenacaoId", "dbo.Coordenacao");
            DropIndex("dbo.Empregado", new[] { "Coordenacao_CoordenacaoId1" });
            DropIndex("dbo.Empregado", new[] { "Coordenacao_CoordenacaoId" });
            DropIndex("dbo.Coordenacao", new[] { "Coordenador_Matricula" });
            DropTable("dbo.Empregado");
            DropTable("dbo.Coordenacao");
        }
    }
}
