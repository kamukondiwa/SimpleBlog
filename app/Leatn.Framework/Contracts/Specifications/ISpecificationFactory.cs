namespace Leatn.Framework.Contracts.Specifications
{
    using System;
    using System.Linq.Expressions;

    using SharpArch.Core.DomainModel;

    /// <summary>
    /// The specification factory contract.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    public interface ISpecificationFactory<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// The get null specification.
        /// </summary>
        /// <returns>
        /// The null specification.
        /// </returns>
        ILinqSpecification<TEntity> GetNullSpecification();

        /// <summary>
        /// The get ad hoc specification.
        /// </summary>
        /// <param name="matchingCriteria">
        ///   The matching Criteria.
        /// </param>
        /// <param name="cachKey"></param>
        /// <returns>
        /// The adhoc specification.
        /// </returns>
        ILinqSpecification<TEntity> GetAdHocSpecification(Expression<Func<TEntity, bool>> matchingCriteria, string cachKey);
    }
}