namespace Leatn.Domain.Specifications
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Domain.Contracts.Specifications;

    using Framework.Contracts.Specifications;

    #endregion

    /// <summary>
    /// The query specification.
    /// </summary>
    /// <typeparam name="T">
    /// The type you are querying on.
    /// </typeparam>
    public abstract class QuerySpecification<T> : ILinqSpecification<T>
    {
        /// <summary>
        /// The null specification.
        /// </summary>
        public static readonly QuerySpecification<T> NullSpecification = new NullQuerySpecification<T>();

        public virtual string CacheKey { get; protected set; }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public virtual Expression<Func<T, bool>> MatchingCriteria
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// satisfying elements from.
        /// </summary>
        /// <param name="candidates">
        /// The candidates.
        /// </param>
        /// <returns>
        /// A list of satisfying elements.
        /// </returns>
        public virtual IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            if (this.MatchingCriteria != null)
            {
                return candidates.Where(this.MatchingCriteria);
            }

            return candidates;
        }
    }
}