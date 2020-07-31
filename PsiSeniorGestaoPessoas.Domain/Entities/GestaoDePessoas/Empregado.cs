using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas
{
    public class Empregado
    {
        public string Matricula { get; private set; }

        public string Nome { get; private set; }

        public virtual Coordenacao Coordenacao { get; private set; }


        public Empregado()
        {

        }

        public Empregado(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }
    }
}
