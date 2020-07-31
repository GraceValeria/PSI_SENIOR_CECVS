using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Data.EntityConfig.GestaoDePessoas
{
    public class EmpregadoConfig : EntityTypeConfiguration<Empregado>
    {
        public EmpregadoConfig()
        {
            HasKey(e => e.Matricula);

            Property(e => e.Nome).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
