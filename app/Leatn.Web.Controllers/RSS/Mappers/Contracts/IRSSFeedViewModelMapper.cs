namespace Leatn.Web.Controllers.RSS.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.RSS.ViewModels;

    #endregion

    /// <summary>
    /// The rss feed view model mapper contract.
    /// </summary>
    public interface IRSSFeedViewModelMapper : IMapper<IEnumerable<BlogPost>, RSSFeedViewModel>
    {
    }
}