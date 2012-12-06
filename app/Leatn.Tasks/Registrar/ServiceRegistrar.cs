namespace Leatn.Tasks.Registrar
{
    using System.ComponentModel.Composition;
    using System.Reflection;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;
    using Framework.Extensions;

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
                     .Pick().FromAssembly(Assembly.GetAssembly(typeof(TasksRegistrar)))
                     .If(f => f.Namespace.Equals("Leatn.Tasks.Services"))
                     .WithService.FirstNonGenericCoreInterface("Leatn.Domain.Contracts.Services"));
        }
    }
}