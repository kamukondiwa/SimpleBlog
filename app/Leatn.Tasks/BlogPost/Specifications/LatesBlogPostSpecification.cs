namespace Leatn.Tasks.BlogPost.Specifications
{
    using System.Linq;

    using Domain.Blog.BlogPost;
    using Domain.Specifications;

    /// <summary>
    /// The lates blog post specification.
    /// </summary>
    public sealed class LatesBlogPostSpecification : QuerySpecification<BlogPost>
    {
        public LatesBlogPostSpecification()
        {
            CacheKey = "latestBlogPosts";
        }

        /// <summary>
        /// The satisfying elements from.
        /// </summary>
        /// <param name="candidates">
        /// The candidates.
        /// </param>
        /// <returns>
        /// The query specification for the 10 latest blog posts.
        /// </returns>
        public override IQueryable<BlogPost> SatisfyingElementsFrom(IQueryable<BlogPost> candidates)
        {
            return candidates.OrderBy(x => x.PostDate).Take(10);
        }
    }
}