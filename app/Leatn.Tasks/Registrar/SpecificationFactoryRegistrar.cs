namespace Leatn.Tasks.Registrar
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Reflection;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;

    using Leatn.Tasks.Properties;

    #endregion

    /// <summary>
    /// The specification factory registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class SpecificationFactoryRegistrar : IComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void Register(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick().FromAssembly(Assembly.GetAssembly(typeof(TasksRegistrarMarker))).If(
                    t => t.Namespace.Contains("Specifications")).WithService.FirstInterface());
        }
    }
}