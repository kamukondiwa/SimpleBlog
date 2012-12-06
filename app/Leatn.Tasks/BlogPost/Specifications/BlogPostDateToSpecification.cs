namespace Leatn.Tasks.BlogPost.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Specifications;

    #endregion

    /// <summary>
    /// The blog post date to specification.
    /// </summary>
    public class BlogPostDateToSpecification : QuerySpecification<BlogPost>
    {
        /// <summary>
        /// The date to.
        /// </summary>
        private readonly DateTime dateTo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostDateToSpecification"/> class.
        /// </summary>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        public BlogPostDateToSpecification(DateTime dateTo)
        {
            this.dateTo = dateTo;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<BlogPost, bool>> MatchingCriteria
        {
            get
            {
                return x => x.PostDate <= this.dateTo;
            }
        }
    }
}