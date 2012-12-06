namespace Leatn.Domain.Contracts.Tasks
{
    #region Using Directives

    using System.Linq;

    using Leatn.Domain.Blog.BlogPost;

    #endregion

    /// <summary>
    /// The blog post tasks contract.
    /// </summary>
    public interface IBlogPostTasks
    {
        /// <summary>
        /// The get latest blog posts.
        /// </summary>
        /// <returns>
        /// The latest blog posts.
        /// </returns>
        IQueryable<BlogPost> GetLatestBlogPosts();
    }
}