namespace Leatn.Tasks.Registrar
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Reflection;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;

    using Leatn.Framework.Extensions;

    #endregion

    /// <summary>
    /// The mapper registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class MapperRegistrar : IComponentRegistrar
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
                AllTypes.Pick().FromAssembly(Assembly.GetAssembly(typeof(TasksRegistrar))).If(
                    f => f.Namespace.Contains("Mappers")).WithService.FirstNonGenericCoreInterface("Leatn.Tasks"));
        }
    }
}