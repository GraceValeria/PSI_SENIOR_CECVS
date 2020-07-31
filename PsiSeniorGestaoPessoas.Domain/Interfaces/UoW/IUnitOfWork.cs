using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
