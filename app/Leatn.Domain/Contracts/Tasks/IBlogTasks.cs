namespace Leatn.Domain.Contracts.Tasks
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Leatn.Domain.Blog;
    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Blog.BlogPostComment;

    #endregion

    /// <summary>
    /// The blog tasks contract.
    /// </summary>
    public interface IBlogTasks
    {
        /// <summary>
        /// The get latest blogs.
        /// </summary>
        /// <returns>
        /// A list of blogs.
        /// </returns>
        IQueryable<Blog> GetLatestBlogs();

        /// <summary>
        /// The blog details save methode.
        /// </summary>
        /// <param name="blogSaveDetails">
        /// The blog save details.
        /// </param>
        void Save(BlogSaveDetails blogSaveDetails);

        /// <summary>
        /// The get blog.
        /// </summary>
        /// <param name="url">
        /// The requested blog's url.
        /// </param>
        /// <returns>
        /// The requested blog.
        /// </returns>
        Blog GetBlog(string url);

        /// <summary>
        /// The blog post save.
        /// </summary>
        /// <param name="blog">
        /// The blog to which the post is to be added.
        /// </param>
        /// <param name="blogPostSaveDetails">
        /// The blog post save details.
        /// </param>
        void Save(Blog blog, BlogPostSaveDetails blogPostSaveDetails);

        /// <summary>
        /// The blog save.
        /// </summary>
        /// <param name="blog">
        /// The blog to save.
        /// </param>
        /// <param name="postCommentSaveDetails">
        /// The post comment save details.
        /// </param>
        void Save(Blog blog, BlogPostCommentSaveDetails postCommentSaveDetails);

        /// <summary>
        /// The get archive blog posts.
        /// </summary>
        /// <param name="blogUrl">
        /// The blog url.
        /// </param>
        /// <param name="archiveYear">
        /// The archive year.
        /// </param>
        /// <returns>
        /// The blog posts.
        /// </returns>
        IEnumerable<BlogPost> GetArchivedBlogPosts(string blogUrl, int archiveYear);

        /// <summary>
        /// The get archive blog posts.
        /// </summary>
        /// <param name="blogUrl">
        /// The blog url.
        /// </param>
        /// <param name="archiveYear">
        /// The archive year.
        /// </param>
        /// <param name="archiveMonth">
        /// The archive month.
        /// </param>
        /// <returns>
        /// The blog posts.
        /// </returns>
        IEnumerable<BlogPost> GetArchivedBlogPosts(string blogUrl, int archiveYear, string archiveMonth);
    }
}