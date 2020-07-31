using PsiSeniorGestaoPessoas.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCore.Events;
using SharedCore.Events.Dto;
using SharedCore.Interfaces;
using AutoMapper;
using PsiSeniorGestaoPessoas.Application.Interfaces;
using PsiSeniorGestaoPessoas.Application.Mapper;

namespace PsiSeniorGestaoPessoas.Application.Services
{
    public abstract class ApplicationServiceBase : IApplicationServiceBase
    {
        private readonly IUnitOfWork UnitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;
        protected readonly IMapper Mapper;
        public ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
            Mapper = AutoMapperConfigPsiSeniorGestaoPessoas.RegisterMappings();
        }

        public bool Save()
        {
            try
            {
                if (Notifications != null && Notifications.GetValues().Count > 0)
                {
                    return false;
                }
                UnitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                StringBuilder erro = new StringBuilder();
                erro.AppendFormat("Ocorreu um comportamento inesperado\n {0}", ex.Message);

                Notifications.Handle(new DomainNotification("UnitOfWorkSave", erro.ToString()));
                return false;
            }
        }

        public string NotificacoesSerializado()
        {
            var notificacoes = Notificacoes();
            var result = new
            {
                sucesso = (notificacoes.Count == 0),
                detalhes = StringfyNotificacoes(notificacoes)
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        private string StringfyNotificacoes(IList<NotificationDto> notificacoes)
        {
            string result = "";
            if (notificacoes.Count > 0) foreach (var notif in notificacoes)
                {
                    result += notif.Key + " " + notif.Value + "<br>";
                }
            return result;
        }

        public IList<NotificationDto> Notificacoes()
        {
            return Mapper.Map<IList<DomainNotification>, IList<NotificationDto>>(Notifications.GetValues()).ToList();
        }

    }
}
