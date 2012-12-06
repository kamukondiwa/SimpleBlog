namespace Leatn.Web.Controllers.Post.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Mapper;

    using ViewModels;

    #endregion

    /// <summary>
    /// The blog post page view model mapper contract.
    /// </summary>
    public interface IBlogPostPageViewModelMapper : IMapper<Blog, BlogPost,Domain.Tags.Tag, BlogPostPageViewModel>
    {
    }
}