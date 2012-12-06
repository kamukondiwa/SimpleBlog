namespace Leatn.Web.Controllers.Shared.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Domain.Contracts;

    using Framework.Enumerable;

    #endregion

    /// <summary>
    /// The archive page view model.
    /// </summary>
    public class ArchiveSectionViewModel : IEmptyAware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveSectionViewModel"/> class.
        /// </summary>
        public ArchiveSectionViewModel()
        {
            this.Archives = new List<ArchiveYearViewModel>();
        }

        /// <summary>
        /// Gets or sets Archives.
        /// </summary>
        public IEnumerable<ArchiveYearViewModel> Archives { get; set; }

        /// <summary>
        /// The is empty.
        /// </summary>
        /// <returns>
        /// The value indicating whether the model is empty.
        /// </returns>r
        public bool IsEmpty()
        {
            return this.Archives.IsNullOrEmpty();
        }
    }
}