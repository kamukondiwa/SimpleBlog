namespace Leatn.Domain.Contracts.Services
{
    #region Using Directives

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Specifications.Contracts;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The linq specification builder service contract.
    /// </summary>
    public interface ILinqSpecificationBuilderService
    {
        /// <summary>
        /// The using.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <typeparam name="T">
        /// The entity type.
        /// </typeparam>
        /// <returns>
        /// An ILinqSpecificationBuilder.
        /// </returns>
        ILinqSpecificationBuilder<T> Using<T>(ILinqSpecification<T> specification) where T : Entity;
    }
}