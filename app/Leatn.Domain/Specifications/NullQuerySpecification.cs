namespace Leatn.Domain.Contracts.Specifications
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Domain.Specifications;

    #endregion

    /// <summary>
    /// The null query specification.
    /// </summary>
    /// <typeparam name="T">
    /// The type you are querying on.
    /// </typeparam>
    public class NullQuerySpecification<T> : QuerySpecification<T>
    {
        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<T, bool>> MatchingCriteria
        {
            get
            {
                return x => true;
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
        public override IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            return candidates;
        }
    }
}