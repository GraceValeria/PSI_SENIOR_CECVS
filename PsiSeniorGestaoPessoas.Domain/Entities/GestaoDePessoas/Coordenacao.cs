using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas
{
    public class Coordenacao
    {
        public string CoordenacaoId { get; private set; }

        public string Nome { get; private set; }

        public string CaixaPostal { get; private set; }

        public virtual Empregado Coordenador { get; private set; }

        public virtual ICollection<Empregado> Empregados { get; private set; }

        public Coordenacao()
        {

        }

        public Coordenacao(string nome, string caixaPostal)
        {
            Nome = nome;
            CaixaPostal = caixaPostal;

        }
    }
}
