[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TesteWTime.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TesteWTime.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace TesteWTime.WebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TesteWTime.Domain.Interfaces.Services;
    using TesteWTime.Domain.Services;
    using TesteWTime.Infra.Repositories;
    using TesteWTime.Domain.Interfaces.Repositories;
    using TesteWTime.Domain.Interfaces;
    using System.Web.Http;
    using System.Collections.Generic;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new LocalNinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        public class LocalNinjectDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
        {
            private readonly IKernel _kernel;

            public LocalNinjectDependencyResolver(IKernel kernel)
            {
                _kernel = kernel;
            }

            public System.Web.Http.Dependencies.IDependencyScope BeginScope()
            {
                return this;
            }

            public object GetService(Type serviceType)
            {
                return _kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return _kernel.GetAll(serviceType);
                }
                catch (Exception)
                {
                    return new List<object>();
                }
            }

            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IUrlsRepository>().To<UrlsRepository>();
            kernel.Bind<IUsersRepository>().To<UsersRepository>();
        }
    }
}