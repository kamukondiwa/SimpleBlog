namespace Leatn.Framework.Contracts.Specifications
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    /// Defines a contract for the behaviour of a LINQ Specification design pattern.
    /// </summary>
    /// <typeparam name="T">
    /// Type to be used for Input / Output
    /// </typeparam>
    public interface ILinqSpecification<T> : ILinqSpecification<T, T>
    {
        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        Expression<Func<T, bool>> MatchingCriteria { get; }
    }

    /// <summary>
    /// Defines a contract for the behaviour of a LINQ Specification design pattern.
    /// </summary>
    /// <typeparam name="T">
    /// The input type.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The output type.
    /// </typeparam>
    public interface ILinqSpecification<T, TResult>
    {
        /// <summary>
        /// satisfying elements from.
        /// </summary>
        /// <param name="candidates">
        /// The candidates.
        /// </param>
        /// <returns>
        /// A list of satisfying elements.
        /// </returns>
        IQueryable<TResult> SatisfyingElementsFrom(IQueryable<T> candidates);

        /// <summary>
        /// Get the cach key.
        /// </summary>
        string CacheKey { get; }
    }
}