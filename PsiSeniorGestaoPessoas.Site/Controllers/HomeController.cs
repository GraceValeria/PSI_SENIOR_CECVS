using Newtonsoft.Json;
using PsiSeniorGestaoPessoas.Site.Models;
using PsiSeniorGestaoPessoas.Application.Interfaces.GestaoDePessoas;
using PsiSeniorGestaoPessoas.Application.Dto.GestaoDePessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharedCore.Helpers;

namespace PsiSeniorGestaoPessoas.Site.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICoordenacaoAppService CoordenacaoAppService;

        public HomeController(ICoordenacaoAppService coordenacaoAppService)
        {
            CoordenacaoAppService = coordenacaoAppService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Gestão De Pessoas";

            var viewModel = new HomeIndexViewModel();
           
            var coordenacoes = CoordenacaoAppService.ListarTodasCoordenacoes();

            if (coordenacoes != null && coordenacoes.Any())
            {
                //viewModel.CoordenacoesJson = JsonConvert.SerializeObject(coordenacoes);
                viewModel.Coordenacoes = coordenacoes;
            }
            else
            {
                viewModel.CoordenacoesJson = JsonConvert.SerializeObject(new List<CoordenacaoDatatableDto>());
            }
            return View(viewModel);
        }


        

        [HttpPost]
        public JsonResult RegistrarEmpregado(string nome, string matricula)
        {

            ICollection<CoordenacaoDatatableDto> coordenacoes = CoordenacaoAppService.RegistrarEmpregado(nome, matricula);

            if (!CoordenacaoAppService.Notificacoes().Any())
            {
                return Json(new
                {
                    sucesso = true,
                    mensagem = $"Empregado registrado com sucesso!",
                    coordenacoes = JsonConvert.SerializeObject(coordenacoes)
                });
            }

            return Json(new
            {
                sucesso = false,
                mensagem = FormataMensagemDeErro.Formatar(CoordenacaoAppService.Notificacoes())
            });
        }


        [HttpPost]
        public JsonResult RegistrarCoordenacao(string nomeCoordenacao, string caixaPostal)
        {

            ICollection<CoordenacaoDatatableDto> coordenacoes = CoordenacaoAppService.RegistrarCoordenacao(nomeCoordenacao, caixaPostal);

            if (!CoordenacaoAppService.Notificacoes().Any())
            {
                return Json(new
                {
                    sucesso = true,
                    mensagem = $"Coordenação registrada com sucesso!",
                    coordenacoes = JsonConvert.SerializeObject(coordenacoes)

                });
            }

            return Json(new
            {
                sucesso = false,
                mensagem = FormataMensagemDeErro.Formatar(CoordenacaoAppService.Notificacoes())
            });
        }


    }
}