using PsiSeniorGestaoPessoas.Infra.TiposExecucao.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.Entity.ModelConfiguration.Conventions;
using PsiSeniorGestaoPessoas.Data.EntityConfig.GestaoDePessoas;

namespace PsiSeniorGestaoPessoas.Data.Context
{
    public class PsiSeniorGestaoPessoasContext : DbContext
    {

        private const string conexaoHomologacao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PsiSeniorGestaoPessoas;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string conexaoProducao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PsiSeniorGestaoPessoas;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string conexaoLocal = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PsiSeniorGestaoPessoas;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static TipoExecucao execucao = Execucao.GetTipoExecucao();

        public PsiSeniorGestaoPessoasContext()
            : base(nameOrConnectionString: GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            if (ehServidorWeb())
                return GetConnectionStringWeb();
            else
                return GetConnectionStringDesktop();
        }

        private static bool ehServidorWeb()
        {
            if (HttpRuntime.AppDomainAppId != null)
                return true;
            return false;
        }

        private static string GetConnectionStringWeb()
        {
            var regex = new Regex(@"^(localhost)|(www.cecvs.hom.sp.caixa)|(www.cecvs.sp.caixa)");

            Match match = regex.Match(HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("http://", "").Replace("https://", ""));
            if (!match.Success)
                throw new Exception("Servidor web não reconhecido (web - match.success = 'false').");

            if (match.Groups[0].ToString() == "localhost" || match.Groups[0].ToString() == "www.cecvs.hom.sp.caixa")
            {
                if (execucao == TipoExecucao.Producao)
                    return conexaoProducao;
                if (execucao == TipoExecucao.Homologacao)
                    return conexaoHomologacao;
                return conexaoLocal;
            }
            else if (match.Groups[0].ToString() == "www.cecvs.sp.caixa")
                return conexaoProducao;
            else
                throw new Exception("URL não reconhecida. Detalhes: " + match.Groups[0].ToString());
        }

        private static string GetConnectionStringDesktop()
        {
            if (execucao == TipoExecucao.Producao)
                return conexaoProducao;
            if (execucao == TipoExecucao.Homologacao)
                return conexaoHomologacao;
            return conexaoLocal;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Desabilita Delete em cascata 1=>N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Desabilita Delete em cascata N=>N

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar").HasMaxLength(200));

            modelBuilder.Configurations.Add(new CoordenacaoConfig());
            modelBuilder.Configurations.Add(new EmpregadoConfig());
            
            // http://www.entityframeworktutorial.net/code-first/configure-classes-in-code-first.aspx
            base.OnModelCreating(modelBuilder);
        }
    }
}
