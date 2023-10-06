using Prueba.Persistencia;
using Prueba.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Prueba.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterUnity();
        }

        private void RegisterUnity()
        {
            var container = new UnityContainer();

            //Persistencia
            container.RegisterType<IClienteRepository, ClienteRepository>();

            //Service
            container.RegisterType<IClienteService, ClienteService>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
