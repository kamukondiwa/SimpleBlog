namespace Leatn.Tasks.Registrar
{
    #region Using Directives

    using System;
    using System.ComponentModel.Composition;
    using System.Reflection;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Framework.Contracts.Container;

    using Leatn.Framework.Extensions;
    using Leatn.Tasks.Properties;

    #endregion

    /// <summary>
    /// The domain component registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class TasksRegistrar : IComponentRegistrar
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
                            .FromAssembly(Assembly.GetAssembly(typeof(TasksRegistrarMarker)))
                            .If(t => t.Name.EndsWith("Tasks", StringComparison.InvariantCultureIgnoreCase))
                            .WithService.FirstInterface());
        }
    }
}