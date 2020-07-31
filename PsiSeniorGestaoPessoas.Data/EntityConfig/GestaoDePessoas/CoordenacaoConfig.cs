using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;

namespace PsiSeniorGestaoPessoas.Data.EntityConfig.GestaoDePessoas
{
    public class CoordenacaoConfig : EntityTypeConfiguration<Coordenacao>
    {
        public CoordenacaoConfig()
        {
            HasKey(c => c.CoordenacaoId);

            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(255);

            Property(c => c.CaixaPostal).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
