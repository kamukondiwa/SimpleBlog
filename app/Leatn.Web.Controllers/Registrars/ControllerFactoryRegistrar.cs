namespace Leatn.Web.Controllers.Registrars
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Web.Mvc;

    using Castle.Windsor;

    using Framework.Contracts.Container;

    using MvcContrib.Castle;

    #endregion

    /// <summary>
    /// The controller factory registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class ControllerFactoryRegistrar : IComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void Register(IWindsorContainer container)
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}