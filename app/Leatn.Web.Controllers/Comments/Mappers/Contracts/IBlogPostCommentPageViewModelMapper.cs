namespace Leatn.Web.Controllers.Comments.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPostComment;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Comments.ViewModels;

    #endregion

    /// <summary>
    /// The blog post comment page view model mapper contract.
    /// </summary>
    public interface IBlogPostCommentPageViewModelMapper : IMapper<BlogPostComment, BlogPostCommentPageViewModel>
    {
    }
}