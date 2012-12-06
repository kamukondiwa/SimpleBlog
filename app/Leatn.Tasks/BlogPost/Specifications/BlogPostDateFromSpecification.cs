namespace Leatn.Tasks.BlogPost.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Specifications;

    #endregion

    /// <summary>
    /// The blog post date from specification.
    /// </summary>
    public class BlogPostDateFromSpecification : QuerySpecification<BlogPost>
    {
        /// <summary>
        /// The date from.
        /// </summary>
        private readonly DateTime dateFrom;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostDateFromSpecification"/> class.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        public BlogPostDateFromSpecification(DateTime dateFrom)
        {
            this.dateFrom = dateFrom;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<BlogPost, bool>> MatchingCriteria
        {
            get
            {
                return x => x.PostDate >= this.dateFrom;
            }
        }
    }
}