using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace PsiSeniorGestaoPessoas.Infra.TiposExecucao.Enums
{
    public class Execucao
    {
        public static TipoExecucao GetTipoExecucao(TipoExecucao force)
        {
            return force;
        }
        public static TipoExecucao GetTipoExecucao()
        {
#if DEBUG
            try
            {
                var domain = new PrincipalContext(ContextType.Domain);
                return TipoExecucao.Homologacao;
            }
            catch (Exception)
            {
                return TipoExecucao.Local;
            }
#else

            return TipoExecucao.Producao;
#endif
        }

    }
}

