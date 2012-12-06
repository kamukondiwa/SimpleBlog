namespace Leatn.Web.Controllers.Blog.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The blog user page view model.
    /// </summary>
    public class BlogUserPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogUserPageViewModel"/> class.
        /// </summary>
        public BlogUserPageViewModel()
        {
            this.Blogs = new List<BlogSummaryViewModel>();
        }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the Blogs.
        /// </summary>
        public IEnumerable<BlogSummaryViewModel> Blogs { get; set; }
    }
}