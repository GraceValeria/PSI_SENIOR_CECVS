using PsiSeniorGestaoPessoas.Data.Context;
using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Domain.Interfaces.Repositories;
using SharedCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Data.Repositories.GestaoDePessoas
{
    public class EmpregadoRepository : RepositoryBase<Empregado>, IEmpregadoRepository
    {
        public EmpregadoRepository(PsiSeniorGestaoPessoasContext context)
            : base(context)
        {
              
        }
    }
}
