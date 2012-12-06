namespace Leatn.Tasks.Comment.Mappers
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPostComment;
    using Leatn.Framework.Mapper;
    using Leatn.Tasks.Comment.Mappers.Contracts;

    #endregion

    /// <summary>
    /// The blog post comment mapper.
    /// </summary>
    public class BlogPostCommentMapper : BaseMapper<BlogPostCommentSaveDetails, BlogPostComment>, IBlogPostCommentMapper
    {
    }
}