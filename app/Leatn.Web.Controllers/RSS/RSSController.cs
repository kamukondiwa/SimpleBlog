namespace Leatn.Web.Controllers.RSS
{
    #region Using Directives

    using System.Web.Mvc;

    using Leatn.Domain.Contracts.Tasks;
    using Leatn.Web.Controllers.RSS.Mappers.Contracts;

    using MvcContrib.ActionResults;

    using Shared.ActionResults;
    using Leatn.Web.Mvc.Attributes;

    #endregion

    /// <summary>
    /// The rss controller.
    /// </summary>
    public class RSSController : Controller
    {
        /// <summary>
        /// The blog post tasks.
        /// </summary>
        private readonly IBlogPostTasks blogPostTasks;

        /// <summary>
        /// The rss feed view model mapper.
        /// </summary>
        private readonly IRSSFeedViewModelMapper rssFeedViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RSSController"/> class.
        /// </summary>
        /// <param name="blogPostTasks">
        /// The blog post tasks.
        /// </param>
        /// <param name="rssFeedViewModelMapper">
        /// The rss feed view model mapper.
        /// </param>
        public RSSController(IBlogPostTasks blogPostTasks, IRSSFeedViewModelMapper rssFeedViewModelMapper)
        {
            this.blogPostTasks = blogPostTasks;
            this.rssFeedViewModelMapper = rssFeedViewModelMapper;
        }

        /// <summary>
        /// The RSS feed.
        /// </summary>
        /// <returns>
        /// The feed view model.
        /// </returns>
        [WebOutputCacheAttrribute]
        public ActionResult Feed()
        {
            var latestBlogPost = this.blogPostTasks.GetLatestBlogPosts();
            var rssFeedViewModel = this.rssFeedViewModelMapper.MapFrom(latestBlogPost);
            return new RssResult(rssFeedViewModel);
        }
    }
}