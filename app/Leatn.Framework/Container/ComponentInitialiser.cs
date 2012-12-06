namespace Leatn.Framework.Container
{
    #region Using Directives

    using System.Reflection;
    using System.Web;

    using System.ComponentModel.Composition.Hosting;

    using Contracts.Container;

    using Enumerable;

    using MEF;

    #endregion

    public static class ComponentInitialiser
    {
        public static void Initialise()
        {
            var catalog = new CatalogBuilder()
                              .ForAssembly(typeof(IComponentRegistrarMarker).Assembly)
                              .ForMvcAssembly(Assembly.GetExecutingAssembly())
                              .ForMvcAssembliesInDirectory(HttpRuntime.BinDirectory, "Leatn*.dll") // Won't work in Partial trust
                              .Build();

            var compositionContainer = new CompositionContainer(catalog);

            compositionContainer.GetExports<IComponentInitialiser>()
                .ForeEach(e => e.Value.Initialise());
        }
    }
}