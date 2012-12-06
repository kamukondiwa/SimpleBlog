namespace Leatn.Tasks.Blog.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Domain.Specifications;

    using Leatn.Domain.Blog;

    #endregion

    /// <summary>
    /// The blog keyword specification.
    /// </summary>
    public class BlogKeywordSpecification : QuerySpecification<Blog>
    {
        /// <summary>
        /// The keywords.
        /// </summary>
        private readonly string keywords;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogKeywordSpecification"/> class.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        internal BlogKeywordSpecification(string keywords)
        {
            this.keywords = keywords;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<Blog, bool>> MatchingCriteria
        {
            get
            {
                return x => x.Title.Contains(this.keywords) || x.Description.Contains(this.keywords);
            }
        }
    }
}