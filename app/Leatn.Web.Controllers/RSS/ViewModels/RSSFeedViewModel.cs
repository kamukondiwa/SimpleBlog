namespace Leatn.Web.Controllers.RSS.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The rss feed view model.
    /// </summary>
    public class RSSFeedViewModel
    {
        /// <summary>
        /// Gets or sets Channel.
        /// </summary>
        public RssElementViewModel Channel { get; set; }

        /// <summary>
        /// Gets or sets Elements.
        /// </summary>
        public List<RssElementViewModel> Elements { get; set; }
    }
}