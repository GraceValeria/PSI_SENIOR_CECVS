using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;

namespace PsiSeniorGestaoPessoas.Domain.Interfaces.Services
{
    public interface ICoordenacaoService
    {
        ICollection<Coordenacao> ListarTodasCoordenacoes();
        void RegistrarCoordenacao(string nomeCoordenacao, string caixaPostal);
        void RegistrarEmpregado(string nome, string matricula);
    }
}
