namespace Leatn.Tasks.BlogPost.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Domain.Blog.BlogPost;
    using Domain.Specifications;

    /// <summary>
    /// The blog post keyword specification.
    /// </summary>
    public class BlogPostKeywordSpecification : QuerySpecification<BlogPost>
    {
        /// <summary>
        /// The keywords.
        /// </summary>
        private readonly string keywords;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostKeywordSpecification"/> class.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        public BlogPostKeywordSpecification(string keywords)
        {
            this.keywords = keywords;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<BlogPost, bool>> MatchingCriteria
        {
            get
            {
                return x => x.Title.Contains(this.keywords) || x.Description.Contains(this.keywords);
            }
        }
    }
}