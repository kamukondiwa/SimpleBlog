namespace Leatn.Web.Controllers.Search.ViewModels
{
    /// <summary>
    /// The search result view model.
    /// </summary>
    public class SearchResultViewModel
    {
        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The is blog post.
        /// </summary>
        /// <returns>
        /// The value indicating whether this search result is a blog post.
        /// </returns>
        public bool IsBlogPost()
        {
            return !string.IsNullOrEmpty(this.BlogUrl) && !string.IsNullOrEmpty(this.Url);
        }
    }
}