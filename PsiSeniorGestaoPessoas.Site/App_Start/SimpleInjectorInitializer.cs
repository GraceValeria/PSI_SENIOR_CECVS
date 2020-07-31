using PsiSeniorGestaoPessoas.IoC;
using SharedCore.Events;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace PsiSeniorGestaoPessoas.Site.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static Container Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.AllowOverridingRegistrations = true;

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            DomainEvent.Container = new DomainEventsContainer(DependencyResolver.Current);

            return container;
        }

        private static void InitializeContainer(Container container)
        {
            //BootstrapperSite.Register(container);
            BootStrapperPsiSeniorGestaoPessoas.Register(container, Lifestyle.Scoped);
        }
    }
}