namespace Leatn.Web.Controllers.Post.ViewModels
{
    /// <summary>
    /// The blog post summary page view model.
    /// </summary>
    public class BlogPostSummaryPageViewModel
    {
        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Teaser { get; set; }

        /// <summary>
        /// Gets or sets PostDate.
        /// </summary>
        public string PostDate { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        public string Url { get; set; }
    }
}