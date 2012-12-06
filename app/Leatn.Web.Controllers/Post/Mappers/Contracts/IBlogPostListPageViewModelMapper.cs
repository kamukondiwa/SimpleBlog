namespace Leatn.Web.Controllers.Post.Mappers.Contracts
{
    using System.Collections.Generic;

    using Blog.ViewModels;

    using Domain.Blog.BlogPost;

    using Framework.Mapper;

    /// <summary>
    /// The blog list page view model mapper contract.
    /// </summary>
    public interface IBlogPostListPageViewModelMapper : IMapper<IEnumerable<BlogPost>, BlogPostListPageViewModel>
    {
    }
}