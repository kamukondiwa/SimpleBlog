namespace Leatn.Web.Controllers.Shared.ViewModels
{
    /// <summary>
    /// Base view model for page views
    /// </summary>
    public class PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewModel"/> class.
        /// </summary>
        public PageViewModel()
        {
            this.ArchiveSectionViewModel = new ArchiveSectionViewModel();
        }

        /// <summary>
        /// Gets or sets ArchiveYearViewModel.
        /// </summary>
        public ArchiveSectionViewModel ArchiveSectionViewModel { get; set; }
    }
}