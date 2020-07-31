using PsiSeniorGestaoPessoas.Application.Dto.GestaoDePessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Application.Interfaces.GestaoDePessoas
{
    public interface ICoordenacaoAppService : IApplicationServiceBase
    {
        ICollection<CoordenacaoDatatableDto> ListarTodasCoordenacoes();
        ICollection<CoordenacaoDatatableDto> RegistrarEmpregado(string nome, string matricula);
        ICollection<CoordenacaoDatatableDto> RegistrarCoordenacao(string nomeCoordenacao, string caixaPostal);
    }
}
