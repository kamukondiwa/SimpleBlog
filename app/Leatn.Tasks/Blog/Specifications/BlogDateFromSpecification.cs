namespace Leatn.Tasks.Blog.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Domain.Specifications;

    using Leatn.Domain.Blog;

    #endregion

    /// <summary>
    /// The blog date from specification.
    /// </summary>
    public class BlogDateFromSpecification : QuerySpecification<Blog>
    {
        /// <summary>
        /// The date from.
        /// </summary>
        private readonly DateTime dateFrom;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDateFromSpecification"/> class.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        public BlogDateFromSpecification(DateTime dateFrom)
        {
            this.dateFrom = dateFrom;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<Blog, bool>> MatchingCriteria
        {
            get
            {
                return x => x.CreationDate >= this.dateFrom;
            }
        }
    }
}