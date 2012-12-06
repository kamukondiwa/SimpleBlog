namespace Leatn.Web.Controllers.Search
{
    #region Using Directives

    using System.Web.Mvc;
    using Mvc.Attributes;

    using Leatn.Web.Controllers.Search.Contracts;
    using Leatn.Web.Controllers.Search.Mappers.Contracts;
    using Leatn.Web.Controllers.Search.ViewModels;

    #endregion

    /// <summary>
    /// The search controller.
    /// </summary>
    public class SearchController : Controller
    {
        /// <summary>
        /// The blog search page view model mapper.
        /// </summary>
        private readonly ISearchPageViewModelMapper blogSearchPageViewModelMapper;

        /// <summary>
        /// The search parameter mapper.
        /// </summary>
        private readonly ISearchParameterMapper searchParameterMapper;

        /// <summary>
        /// The search tasks.
        /// </summary>
        private readonly ISearchTasks searchTasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="blogSearchPageViewModelMapper">
        /// The blog search page view model mapper.
        /// </param>
        /// <param name="searchParameterMapper">
        /// The search parameter mapper.
        /// </param>
        /// <param name="searchTasks">
        /// The search Tasks.
        /// </param>
        public SearchController(
            ISearchPageViewModelMapper blogSearchPageViewModelMapper, 
            ISearchParameterMapper searchParameterMapper, 
            ISearchTasks searchTasks)
        {
            this.searchTasks = searchTasks;
            this.searchParameterMapper = searchParameterMapper;
            this.blogSearchPageViewModelMapper = blogSearchPageViewModelMapper;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="form">
        /// The form view model.
        /// </param>
        /// <returns>
        /// The search view result.
        /// </returns>
        [WebOutputCacheAttrribute(VaryByParam = "*")]
        public ActionResult Index(SearchFormViewModel form)
        {
            var searchParameters = this.searchParameterMapper.MapFrom(form);

            var searchResult = this.searchTasks.Search(searchParameters);

            var searchPageViewModel = this.blogSearchPageViewModelMapper.MapFrom(searchResult, searchParameters.ContentType, form);

            return this.View(searchPageViewModel);
        }
    }
}