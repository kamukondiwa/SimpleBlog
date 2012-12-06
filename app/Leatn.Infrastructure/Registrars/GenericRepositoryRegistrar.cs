namespace Leatn.Infrastructure.Registrars
{
    #region Using Directives

    using System.ComponentModel.Composition;

    using Castle.Windsor;

    using Domain.Contracts.Repositories;

    using Framework.Contracts.Container;

    using NHibernate;

    #endregion

    [Export(typeof(IComponentRegistrar))]
    public class GenericRepositoryRegistrar : IComponentRegistrar
    {
        public void Register(IWindsorContainer container)
        {
            container.AddComponent("linqRepository", typeof(ILinqRepository<>), typeof(LinqRepository<>));
        }
    }
}