using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Domain.Interfaces.Repositories;
using PsiSeniorGestaoPessoas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Domain.Services.GestaoDePessoas
{
    public class CoordenacaoService : ICoordenacaoService
    {
        private readonly ICoordenacaoRepository CoordenacaoRepository;
        private readonly IEmpregadoRepository EmpregadoRepository;

        public CoordenacaoService(ICoordenacaoRepository coordenacaoRepository,
                                  IEmpregadoRepository empregadoRepository)
        {
            CoordenacaoRepository = coordenacaoRepository;
            EmpregadoRepository = empregadoRepository;
        }

        public ICollection<Coordenacao> ListarTodasCoordenacoes() => CoordenacaoRepository.GetAll();

        public void RegistrarCoordenacao(string nomeCoordenacao, string caixaPostal)
        {
            Coordenacao coordenacaoNova = new Coordenacao(nomeCoordenacao, caixaPostal);

            CoordenacaoRepository.Insert(coordenacaoNova);

        }


        public void RegistrarEmpregado(string nome, string matricula)
        {
            Empregado empregadoNovo = new Empregado(nome, matricula);

            EmpregadoRepository.Insert(empregadoNovo);

        }
    }
}
