using PsiSeniorGestaoPessoas.Application.Interfaces.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Application.Services.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Data.Context;
using PsiSeniorGestaoPessoas.Data.Repositories.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Data.UoW;
using PsiSeniorGestaoPessoas.Domain.Interfaces.Repositories;
using PsiSeniorGestaoPessoas.Domain.Interfaces.Services;
using PsiSeniorGestaoPessoas.Domain.Interfaces.UoW;
using PsiSeniorGestaoPessoas.Domain.Services.GestaoDePessoas;
using SharedCore.Events;
using SharedCore.Handlers;
using SharedCore.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiSeniorGestaoPessoas.IoC
{
    public class BootStrapperPsiSeniorGestaoPessoas
    {
        public static void Register(Container container, Lifestyle lifeStyle)
        {

            #region AppServices

            container.Register<ICoordenacaoAppService, CoordenacaoAppService>(lifeStyle);
            //container.Register<IDemandaAppService, DemandaAppService>(lifeStyle);

            #endregion

            #region Services

            container.Register<ICoordenacaoService, CoordenacaoService>(lifeStyle);
            //container.Register<IDemandaService, DemandaService>(lifeStyle);


            #endregion

            #region Repositories


            container.Register<ICoordenacaoRepository, CoordenacaoRepository>(lifeStyle);
            container.Register<IEmpregadoRepository, EmpregadoRepository>(lifeStyle);


            #endregion

            #region Demais Classes

            container.Register<IUnitOfWork, UnitOfWork>(lifeStyle);
            container.Register<PsiSeniorGestaoPessoasContext>(lifeStyle);
            //Comentar a linha abaixo quando for usar o importador
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(lifeStyle);
            #endregion
        }
    }
}
