using PsiSeniorGestaoPessoas.Application.Dto.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Site.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsiSeniorGestaoPessoas.Site.Models
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public string CoordenacoesJson { get; set; }

        public ICollection<CoordenacaoDatatableDto> Coordenacoes { get; set; }

        public HomeIndexViewModel()
           : base()
        {
            Coordenacoes = new List<CoordenacaoDatatableDto>();
        }
    }
}