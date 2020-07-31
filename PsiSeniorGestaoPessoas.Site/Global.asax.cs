using PsiSeniorGestaoPessoas.Site.App_Start;
using SharedCore.Helpers;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PsiSeniorGestaoPessoas.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            var container = SimpleInjectorInitializer.Initialize();
            // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

            //string matricula = TextoHelper.PegarTextoDireita(HttpContext.Current.User.Identity.Name, 7).ToUpper();

            //if (!Request.Browser.Type.Contains("Firefox"))
            //{
            //    Response.Redirect("~/Erro.aspx", true);
            //}
        }
    }
}
