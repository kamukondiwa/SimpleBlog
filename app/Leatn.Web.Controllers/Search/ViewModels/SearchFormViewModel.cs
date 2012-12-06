namespace Leatn.Web.Controllers.Search.ViewModels
{
    #region Using Directives

    using System;

    using Leatn.Domain.Shared;

    #endregion

    /// <summary>
    /// The search form view model.
    /// </summary>
    public class SearchFormViewModel
    {
        /// <summary>
        /// Gets or sets ContentType.
        /// </summary>
        public SearchContentType ContentType { get; set; }

        /// <summary>
        /// Gets or sets DateFrom.
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Gets or sets DateTo.
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Gets or sets Keywords.
        /// </summary>
        public string Keywords { get; set; }
    }
}