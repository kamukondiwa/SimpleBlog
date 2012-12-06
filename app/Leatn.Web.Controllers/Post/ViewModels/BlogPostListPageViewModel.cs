namespace Leatn.Web.Controllers.Blog.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Web.Controllers.Post.ViewModels;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The blog list page view model.
    /// </summary>
    public class BlogPostListPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostListPageViewModel"/> class.
        /// </summary>
        public BlogPostListPageViewModel()
        {
            this.Results = new List<BlogPostSummaryPageViewModel>();
        }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets Results.
        /// </summary>
        public IEnumerable<BlogPostSummaryPageViewModel> Results { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ShowAddPostLink.
        /// </summary>
        public bool ShowAddPostLink { get; set; }
    }
}