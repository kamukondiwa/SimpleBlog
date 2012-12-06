namespace Leatn.Web.CastleWindsor
{
    #region Using Directives

    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using System.Web;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;

    using Leatn.Framework.Container.MEF;
    using Leatn.Framework.Enumerable;

    using SharpArch.Core.PersistenceSupport;
    using SharpArch.Core.PersistenceSupport.NHibernate;
    using SharpArch.Data.NHibernate;
    using SharpArch.Web.Castle;

    #endregion

    /// <summary>
    /// The component registrar.
    /// </summary>
    public class ComponentRegistrar
    {
        /// <summary>
        /// The add components to.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void Register(IWindsorContainer container)
        {
            var catalog =
                new CatalogBuilder()
                .ForAssembly(typeof(IComponentRegistrarMarker).Assembly)
                .ForMvcAssembly(Assembly.GetExecutingAssembly())
                .ForMvcAssembliesInDirectory(HttpRuntime.BinDirectory, "Leatn*.dll")// Won't work in Partial trust
                .Build();

            var compositionContainer = new CompositionContainer(catalog);

            compositionContainer.GetExports<IComponentRegistrar>().ForeEach(e => e.Value.Register(container));
        }

        /// <summary>
        /// The add custom repositories to.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick().FromAssemblyNamed("Leatn.Infrastructure").WithService.FirstNonGenericCoreInterface(
                    "Leatn.Domain"));
        }

        /// <summary>
        /// The add generic repositories to.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.AddComponent(
                "entityDuplicateChecker", typeof(IEntityDuplicateChecker), typeof(EntityDuplicateChecker));
            container.AddComponent("repositoryType", typeof(IRepository<>), typeof(Repository<>));
            container.AddComponent(
                "nhibernateRepositoryType", typeof(INHibernateRepository<>), typeof(NHibernateRepository<>));
            container.AddComponent(
                "repositoryWithTypedId", typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            container.AddComponent(
                "nhibernateRepositoryWithTypedId",
                typeof(INHibernateRepositoryWithTypedId<,>),
                typeof(NHibernateRepositoryWithTypedId<,>));
        }
    }
}