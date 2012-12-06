namespace Leatn.Web.Controllers.Registrars
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Reflection;

    using Blog.Mappers;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;

    using Leatn.Framework.Extensions;
    using Leatn.Web.Controllers.Properties;

    using Tasks.Blog.Mappers.Contracts;

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
                AllTypes.Pick()
                .FromAssembly(Assembly.GetAssembly(typeof(ControllersRegistrarMarker)))
                .If(f => f.Namespace.Contains("Mappers"))
                .WithService.FirstNonGenericCoreInterface("Leatn.Web.Controllers"));
        }
    }
}