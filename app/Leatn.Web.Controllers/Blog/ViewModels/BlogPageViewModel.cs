namespace Leatn.Web.Controllers.Blog.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Web.Controllers.Post.ViewModels;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The blog page view model.
    /// </summary>
    public class BlogPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPageViewModel"/> class.
        /// </summary>
        public BlogPageViewModel()
        {
            this.Form = new BlogFormViewModel();
        }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets BlogPosts.
        /// </summary>
        public IEnumerable<BlogPostSummaryPageViewModel> BlogPosts { get; set; }

        /// <summary>
        /// Gets or sets CreationDate.
        /// </summary>
        public string CreationDate { get; set; }

        /// <summary>
        /// Gets or sets Form.
        /// </summary>
        public BlogFormViewModel Form { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Checked.
        /// </summary>
        public bool ShowAddPostLink { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show the other blogs link.
        /// </summary>
        public bool ShowOtherBlogsLink { get; set; }
    }
}