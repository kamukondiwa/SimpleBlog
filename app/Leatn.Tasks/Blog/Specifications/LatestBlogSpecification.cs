namespace Leatn.Tasks.Blog.Specifications
{
    using System.Linq;

    using Domain.Blog;
    using Domain.Specifications;

    /// <summary>
    /// The latest blog specification.
    /// </summary>
    public sealed class LatestBlogSpecification : QuerySpecification<Blog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LatestBlogSpecification"/> class.
        /// </summary>
        internal LatestBlogSpecification()
        {
            CacheKey = "latestBlogs";
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
        public override IQueryable<Blog> SatisfyingElementsFrom(IQueryable<Blog> candidates)
        {
            return candidates.OrderBy(x => x.CreationDate).Take(10);
        }
    }
}