namespace Leatn.Web.Controllers.Search.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Web.Mvc;

    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The search page view model.
    /// </summary>
    public class SearchPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Leatn.Web.Controllers.Search.ViewModels.SearchPageViewModel"/> class.
        /// </summary>
        public SearchPageViewModel()
        {
            this.ContentTypes = new List<SelectListItem>();
            this.Results = new List<SearchResultViewModel>();
        }

        /// <summary>
        /// Gets or sets ContentTypes.
        /// </summary>
        public IEnumerable<SelectListItem> ContentTypes { get; set; }

        /// <summary>
        /// Gets or sets DateFrom.
        /// </summary>
        public string DateFrom { get; set; }

        /// <summary>
        /// Gets or sets DateTo.
        /// </summary>
        public string DateTo { get; set; }

        /// <summary>
        /// Gets or sets Form.
        /// </summary>
        public SearchFormViewModel Form { get; set; }

        /// <summary>
        /// Gets or sets Results.
        /// </summary>
        public IEnumerable<SearchResultViewModel> Results { get; set; }
    }
}