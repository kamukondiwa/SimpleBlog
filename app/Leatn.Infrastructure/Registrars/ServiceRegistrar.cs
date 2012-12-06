namespace Leatn.Infrastructure.Registrars
{
    #region Using Directives

    using System;
    using System.ComponentModel.Composition;
    using System.Reflection;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;
    using Framework.Extensions;

    using Properties;

    #endregion

    /// <summary>
    /// The service registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class ServiceRegistrar : IComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void Register(IWindsorContainer container)
        {
            container.Register(AllTypes
                     .Pick().FromAssembly(Assembly.GetAssembly(typeof(InfrastructureRegistrarMarker)))
                     .If(f => f.Namespace.Equals("Leatn.Infrastructure.Services"))
                     .WithService.FirstNonGenericCoreInterface("Leatn.Domain.Contracts.Services"));
        }
    }
}