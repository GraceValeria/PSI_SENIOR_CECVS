using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCore.Events.Dto;

namespace PsiSeniorGestaoPessoas.Application.Interfaces
{
    public interface IApplicationServiceBase
    {
        IList<NotificationDto> Notificacoes();
        string NotificacoesSerializado();
    }
}
