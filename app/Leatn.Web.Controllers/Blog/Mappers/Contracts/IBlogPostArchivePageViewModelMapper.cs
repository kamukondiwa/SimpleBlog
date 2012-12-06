namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Mapper;

    using ViewModels;

    #endregion

    /// <summary>
    /// The blog post archive page view model mapper contract.
    /// </summary>
    public interface IBlogPostArchivePageViewModelMapper : IMapper<IEnumerable<BlogPost>, BlogPostArchivePageViewModel>
    {
    }
}