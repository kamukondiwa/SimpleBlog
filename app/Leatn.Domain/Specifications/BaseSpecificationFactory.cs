namespace Leatn.Domain.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Domain.Contracts.Specifications;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Specifications.Contracts;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The base specification factory.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The Entity type.
    /// </typeparam>
    public class BaseSpecificationFactory<TEntity> : ISpecificationFactory<TEntity>
        where TEntity : Entity
    {
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
        public ILinqSpecification<TEntity> GetAdHocSpecification(Expression<Func<TEntity, bool>> matchingCriteria, string cachKey)
        {
            return new AdHocSpecification<TEntity>(matchingCriteria, cachKey);
        }

        /// <summary>
        /// The get null specification.
        /// </summary>
        /// <returns>
        /// The null specification.
        /// </returns>
        public ILinqSpecification<TEntity> GetNullSpecification()
        {
            return new NullQuerySpecification<TEntity>();
        }
    }
}