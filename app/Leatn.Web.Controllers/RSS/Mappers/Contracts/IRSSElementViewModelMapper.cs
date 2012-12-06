namespace Leatn.Web.Controllers.RSS.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.RSS.ViewModels;

    #endregion

    /// <summary>
    /// The rss element view model mapper contract.
    /// </summary>
    public interface IRSSElementViewModelMapper : IMapper<BlogPost, RssElementViewModel>
    {
    }
}