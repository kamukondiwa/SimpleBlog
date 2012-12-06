namespace Leatn.Domain.Contracts.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Domain.Specifications;

    #endregion

    /// <summary>
    /// The ad hoc specificaiton.
    /// </summary>
    /// <typeparam name="T">
    /// The type you are qurying on.
    /// </typeparam>
    public sealed class AdHocSpecification<T> : QuerySpecification<T>
    {
        /// <summary>
        /// The expression.
        /// </summary>
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdHocSpecification{T}"/> class.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="cachKey">
        /// The cache key.
        /// </param>
        public AdHocSpecification(Expression<Func<T, bool>> expression, string cachKey)
        {
            this.expression = expression;
            this.CacheKey = cachKey;
        }

        public AdHocSpecification(Expression<Func<T, bool>> expression)
            : this(expression, string.Empty)
        {
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<T, bool>> MatchingCriteria
        {
            get
            {
                return this.expression;
            }
        }
    }
}