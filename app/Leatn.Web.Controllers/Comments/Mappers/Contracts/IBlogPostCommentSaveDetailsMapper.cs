namespace Leatn.Web.Controllers.Comments.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPostComment;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Comments.ViewModels;

    #endregion

    /// <summary>
    /// The blog post comment save details mapper contract.
    /// </summary>
    public interface IBlogPostCommentSaveDetailsMapper :
        IMapper<BlogPostCommentFormViewModel, BlogPostCommentSaveDetails>
    {
    }
}