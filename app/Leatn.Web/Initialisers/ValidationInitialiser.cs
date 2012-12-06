namespace Leatn.Web.Initialisers
{
    #region Using Directives

    using System.ComponentModel.Composition;

    using Framework.Contracts.Container;

    using Leatn.Web.Code;

    using NHibernate.Validator.Cfg;
    using NHibernate.Validator.Event;

    using xVal;

    #endregion

    /// <summary>
    /// The validation initialiser.
    /// </summary>
    [Export(typeof(IComponentInitialiser))]
    public class ValidationInitialiser : IComponentInitialiser
    {
        /// <summary>
        /// The initialise.
        /// </summary>
        public void Initialise()
        {
            var provider = new NHibernateSharedEngineProvider();
            Environment.SharedEngineProvider = provider;

            ActiveRuleProviders.Providers.Add(new ValidatorRulesProvider());
        }
    }
}