namespace Leatn.Web.Controllers.Registrars
{
    using System.ComponentModel.Composition;

    using Castle.Windsor;

    using Framework.Contracts.Container;

    using SharpArch.Core.CommonValidator;
    using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;

    /// <summary>
    /// The validation registrar.
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class ValidationRegistrar : IComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void Register(IWindsorContainer container)
        {
            container.AddComponent<IValidator, Validator>("validator");
        }
    }
}