namespace Leatn.Web.Controllers.Post.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Mapper;

    using ViewModels;

    #endregion

    /// <summary>
    /// The blog post form view model mapper contract.
    /// </summary>
    public interface IBlogPostFormViewModelMapper : IMapper<BlogPost, BlogPostFormViewModel>
    {
    }
}