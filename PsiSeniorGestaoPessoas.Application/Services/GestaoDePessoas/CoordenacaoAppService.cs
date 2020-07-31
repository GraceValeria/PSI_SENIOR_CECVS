using PsiSeniorGestaoPessoas.Application.Dto.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Application.Interfaces.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Domain.Entities.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Domain.Interfaces.Services;
using PsiSeniorGestaoPessoas.Domain.Interfaces.UoW;
using SharedCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.Application.Services.GestaoDePessoas
{
    public class CoordenacaoAppService : ApplicationServiceBase, ICoordenacaoAppService
    {
        private readonly ICoordenacaoService CoordenacaoService;

        public CoordenacaoAppService(IUnitOfWork unitOfWork,
                                    ICoordenacaoService coordenacaoService)
           : base(unitOfWork)
        {
            CoordenacaoService = coordenacaoService;
        }

        public ICollection<CoordenacaoDatatableDto> ListarTodasCoordenacoes() =>
            Mapper.Map<ICollection<Coordenacao>, ICollection<CoordenacaoDatatableDto>>(CoordenacaoService.ListarTodasCoordenacoes());

        public ICollection<CoordenacaoDatatableDto> RegistrarCoordenacao(string nomeCoordenacao, string caixaPostal)
        {
            try
            {
                CoordenacaoService.RegistrarCoordenacao(nomeCoordenacao, caixaPostal);

                if (Save())
                {
                    return ListarTodasCoordenacoes();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Notifications.Handle(new DomainNotification("Registrar Empregado", ex.Message));
            }

            return null;
        }

        public ICollection<CoordenacaoDatatableDto> RegistrarEmpregado(string nome, string matricula)
        {
            try
            {
                CoordenacaoService.RegistrarEmpregado(nome, matricula);

                if (Save())
                {
                    return ListarTodasCoordenacoes();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Notifications.Handle(new DomainNotification("Registrar Empregado", ex.Message));
            }

            return null;
        }
    }
}
