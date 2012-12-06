namespace Leatn.Web.Controllers.Blog.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Web.Controllers.Post.ViewModels;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The blog post archive page view model.
    /// </summary>
    public class BlogPostArchivePageViewModel : PageViewModel
    {
        /// <summary>
        /// Gets or sets Results.
        /// </summary>
        public IEnumerable<BlogPostSummaryPageViewModel> Results { get; set; }
    }
}