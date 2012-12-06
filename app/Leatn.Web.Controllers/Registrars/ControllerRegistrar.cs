namespace Leatn.Web.Controllers.Registrars
{
    #region Using Directives

    using System;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using Castle.Core;
    using Castle.Windsor;

    using Framework.Contracts.Container;

    using Leatn.Web.Controllers.Properties;

    using Machine.Specifications.Utility;

    #endregion

    /// <summary>
    /// The controller registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class ControllerRegistrar : IComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void Register(IWindsorContainer container)
        {
            Assembly.GetAssembly(typeof(ControllersRegistrarMarker))
                    .GetExportedTypes()
                    .Where(IsController)
                    .Each(type => container.AddComponentLifeStyle(type.Name.ToLower(), type, LifestyleType.Transient));
        }

        /// <summary>
        /// Helper method to check to see if the specified type a MVC Controller
        /// </summary>
        /// <param name="type">
        /// The type to test.
        /// </param>
        /// <returns>
        /// Whether the type specified is a MVC Controller.
        /// </returns>
        private static bool IsController(Type type)
        {
            return typeof(IController).IsAssignableFrom(type);
        }
    }
}