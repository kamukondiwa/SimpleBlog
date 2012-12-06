namespace Leatn.Web.Mvc.Registrars
{
    #region Using Directives

    using System.ComponentModel.Composition;

    using Caching;
    using Caching.Contracts;

    using Castle.Windsor;

    using Framework.Contracts.Container;
    using Castle.Core;

    #endregion

    [Export(typeof(IComponentRegistrar))]
    public class ComponentRegistrar : IComponentRegistrar
    {
        public void Register(IWindsorContainer container)
        {
            container.AddComponent<ICachingProvider, CachingProvider>()
                     .AddComponentLifeStyle<ICachingProvider>(LifestyleType.Singleton);
        }
    }
}