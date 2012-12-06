namespace Leatn.Domain.Specifications.Contracts
{
    #region Using Directives

    using Framework.Contracts.Specifications;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The linq specification builder contract.
    /// </summary>
    /// <typeparam name="T">
    /// The entity type.
    /// </typeparam>
    public interface ILinqSpecificationBuilder<T>
        where T : Entity
    {
        /// <summary>
        /// The using.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The linq specification starting point.
        /// </returns>
        ILinqSpecificationBuilder<T> Using(ILinqSpecification<T> specification);

        /// <summary>
        /// The and operation.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The result of the current linq specification And the specified specification.
        /// </returns>
        ILinqSpecificationBuilder<T> And(ILinqSpecification<T> specification);

        /// <summary>
        /// The or operation.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The result of the current linq specification Or the specified specification.
        /// </returns>
        ILinqSpecificationBuilder<T> Or(ILinqSpecification<T> specification);

        /// <summary>
        /// The to specification.
        /// </summary>
        /// <returns>
        /// The built up specification.
        /// </returns>
        ILinqSpecification<T> ToSpecification();
    }
}