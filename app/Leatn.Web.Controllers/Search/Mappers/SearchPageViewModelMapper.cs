namespace Leatn.Web.Controllers.Search.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Leatn.Domain.Shared;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Search.Mappers.Contracts;
    using Leatn.Web.Controllers.Search.ViewModels;

    #endregion

    /// <summary>
    /// The blog search page view model mapper.
    /// </summary>
    public class SearchPageViewModelMapper : ISearchPageViewModelMapper
    {
        /// <summary>
        /// The search content type select list mapper.
        /// </summary>
        private readonly ISearchContentTypeSelectListMapper searchContentTypeSelectListMapper;

        /// <summary>
        /// The search result view model mapper.
        /// </summary>
        private readonly ISearchResultViewModelMapper searchResultViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPageViewModelMapper"/> class.
        /// </summary>
        /// <param name="searchResultViewModelMapper">
        /// The search result view model mapper.
        /// </param>
        /// <param name="searchContentTypeSelectListMapper">
        /// The search Content Type Select List Mapper.
        /// </param>
        public SearchPageViewModelMapper(
            ISearchResultViewModelMapper searchResultViewModelMapper, 
            ISearchContentTypeSelectListMapper searchContentTypeSelectListMapper)
        {
            this.searchResultViewModelMapper = searchResultViewModelMapper;
            this.searchContentTypeSelectListMapper = searchContentTypeSelectListMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="searchResults">
        /// The input.
        /// </param>
        /// <param name="searchContentType">
        /// The search Content Type.
        /// </param>
        /// <param name="searchForm">
        /// The search Form.
        /// </param>
        /// <returns>
        /// The blog search page view model.
        /// </returns>
        public SearchPageViewModel MapFrom(
            IEnumerable<AddressableContentBase> searchResults, 
            SearchContentType searchContentType, 
            SearchFormViewModel searchForm)
        {
            var pageViewModel = new SearchPageViewModel
                {
                    Results = searchResults.ToList().MapAllUsing(this.searchResultViewModelMapper), 
                    ContentTypes = this.searchContentTypeSelectListMapper.MapFrom(searchContentType), 
                    Form = searchForm
                };

            if (searchForm.DateFrom.HasValue)
            {
                pageViewModel.DateFrom = searchForm.DateFrom.Value.ToString("dd MMMM yyyy");
            }

            if (searchForm.DateTo.HasValue)
            {
                pageViewModel.DateTo = searchForm.DateTo.Value.ToString("dd MMMM yyyy");
            }

            return pageViewModel;
        }
    }
}