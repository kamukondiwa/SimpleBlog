namespace Leatn.Tasks.Comment.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPostComment;
    using Leatn.Framework.Mapper;

    #endregion

    /// <summary>
    /// The blog post comment mapper contracts.
    /// </summary>
    public interface IBlogPostCommentMapper : IMapper<BlogPostCommentSaveDetails, BlogPostComment>
    {
    }
}