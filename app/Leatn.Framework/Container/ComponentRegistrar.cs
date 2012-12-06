namespace Leatn.Framework.Container
{
    #region Using Directives

    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using System.Web;

    using Castle.Windsor;

    using Leatn.Framework.Container.MEF;
    using Leatn.Framework.Contracts.Container;
    using Leatn.Framework.Enumerable;

    #endregion

    /// <summary>
    /// The component registrar.
    /// </summary>
    public static class ComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void Register(IWindsorContainer container)
        {
            var catalog =
                new CatalogBuilder().ForAssembly(typeof(IComponentRegistrarMarker).Assembly).ForMvcAssembly(
                    Assembly.GetExecutingAssembly()).ForMvcAssembliesInDirectory(HttpRuntime.BinDirectory, "Leatn*.dll")
                    .Build();

            var compositionContainer = new CompositionContainer(catalog);
            compositionContainer.GetExports<IComponentRegistrar>().ForeEach(e => e.Value.Register(container));
        }
    }
}