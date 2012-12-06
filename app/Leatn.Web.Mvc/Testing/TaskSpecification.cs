namespace Leatn.Web.Mvc.Testing
{
    #region Using Directives

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using CommonServiceLocator.WindsorAdapter;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    using Microsoft.Practices.ServiceLocation;

    using Rhino.Mocks;

    using SharpArch.Core.CommonValidator;
    using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;

    #endregion

    /// <summary>
    /// The task specification.
    /// Establishes a contect suited to tasks classes.
    /// </summary>
    /// <typeparam name="T">
    /// The Tasks class that is to be tested.
    /// </typeparam>
    public abstract class TaskSpecification<T> : Specification<T>
    {
        protected static IValidator validator;

        Establish context = () =>
            {
                validator = MockRepository.GenerateMock<IValidator>();
                var container = new WindsorContainer();

                container.Register(Component.For<IValidator>().ImplementedBy<Validator>());
                ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            };
    }
}