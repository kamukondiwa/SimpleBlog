namespace Leatn.Web.Controllers.Shared.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The archive year view model.
    /// </summary>
    public class ArchiveYearViewModel
    {
        /// <summary>
        /// Gets or sets ArchiveMonths.
        /// </summary>
        public IEnumerable<ArchiveMonthViewModel> ArchiveMonths { get; set; }

        /// <summary>
        /// Gets or sets ArchiveYear.
        /// </summary>
        public int ArchiveYear { get; set; }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }
    }
}