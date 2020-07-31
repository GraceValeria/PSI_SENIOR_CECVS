using PsiSeniorGestaoPessoas.Data.Context;
using PsiSeniorGestaoPessoas.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private PsiSeniorGestaoPessoasContext Context;

        public UnitOfWork(PsiSeniorGestaoPessoasContext context)
        {
            Context = context;
        }

        public void Save()
        {
            Context.SaveChanges();
        }


        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            if (Context == null)
                return;

            Context.Dispose();
            Context = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
