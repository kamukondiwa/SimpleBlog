namespace Leatn.Framework.Contracts.Container
{
    using Castle.Windsor;

    /// <summary>
    /// The component registrar contract.
    /// </summary>
    public interface IComponentRegistrar
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        void Register(IWindsorContainer container);
    }
}