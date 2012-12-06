namespace Leatn.Web.Controllers.Search.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using Domain.Blog.BlogPost;
    using Domain.Shared;

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Search.ViewModels;

    #endregion

    /// <summary>
    /// The search page view model mapper contract.
    /// </summary>
    public interface ISearchPageViewModelMapper : IMapper<IEnumerable<AddressableContentBase>, SearchContentType, SearchFormViewModel, SearchPageViewModel>
    {
    }
}