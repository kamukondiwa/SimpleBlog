namespace Leatn.Tasks.Blog.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Domain.Specifications;

    using Leatn.Domain.Blog;

    #endregion

    /// <summary>
    /// The blog date to specification.
    /// </summary>
    public class BlogDateToSpecification : QuerySpecification<Blog>
    {
        /// <summary>
        /// The date to.
        /// </summary>
        private readonly DateTime dateTo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogDateToSpecification"/> class.
        /// </summary>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        public BlogDateToSpecification(DateTime dateTo)
        {
            this.dateTo = dateTo;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<Blog, bool>> MatchingCriteria
        {
            get
            {
                return x => x.CreationDate <= this.dateTo;
            }
        }
    }
}