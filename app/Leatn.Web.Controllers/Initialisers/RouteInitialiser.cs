namespace Leatn.Web.Controllers.Initialisers
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Framework.Contracts.Container;

    using Leatn.Web.Mvc;

    #endregion

    /// <summary>
    /// The route initialiser.
    /// </summary>
    [Export(typeof(IComponentInitialiser))]
    public class RouteInitialiser : IComponentInitialiser
    {
        /// <summary>
        /// The initialise.
        /// </summary>
        public void Initialise()
        {
            var routes = RouteTable.Routes;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{filename}.ashx/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            // taxonomy route.
            var taxonomyRouteOptions = new { controller = "tag", action = "tags", tagId = string.Empty};
            const string TaxonomyRouteValues = "tags/{tagId}";

            routes.Add(new LowercaseRoute(TaxonomyRouteValues, new RouteValueDictionary(taxonomyRouteOptions), new MvcRouteHandler()));

            // Search route.
            var searchOptions = new { controller = "rss", action = "feed", url = string.Empty, postUrl = string.Empty };
            const string SearchValues = "rss";

            routes.Add(new LowercaseRoute(SearchValues, new RouteValueDictionary(searchOptions), new MvcRouteHandler()));

            // Rss route.
            var rssOptions = new { controller = "search", action = "index", url = string.Empty, postUrl = string.Empty };
            const string RssValues = "search";

            routes.Add(new LowercaseRoute(RssValues, new RouteValueDictionary(rssOptions), new MvcRouteHandler()));

            // blog post archive.
            var blogPostArchiveOptions = new { controller = "blog", action = "archiveByYear", url = string.Empty, archiveYear = string.Empty };
            const string BlogPostArchiveValues = "archive/{url}/{archiveYear}";

            routes.Add(new LowercaseRoute(BlogPostArchiveValues, new RouteValueDictionary(blogPostArchiveOptions), new MvcRouteHandler()));

            // user blog listing.
            var userBlogListingOptions = new { controller = "blog", action = "ReadUserBlogs", username = string.Empty };
            const string UserBlogListingValues = "{username}/blogs";

            routes.Add(new LowercaseRoute(UserBlogListingValues, new RouteValueDictionary(userBlogListingOptions), new MvcRouteHandler()));

            // blog post archive.
            var blogPostArchiveMonthOptions = new { controller = "blog", action = "archiveByMonth", url = string.Empty, archiveYear = string.Empty, archiveMonth = string.Empty };
            const string BlogPostArchiveMonthValues = "archive/{url}/{archiveMonth}/{archiveYear}";

            routes.Add(new LowercaseRoute(BlogPostArchiveMonthValues, new RouteValueDictionary(blogPostArchiveMonthOptions), new MvcRouteHandler()));

            // blog route.
            var routeOptions = new { controller = "blog", action = "index", url = string.Empty, postUrl = string.Empty };
            const string RouteValues = "{action}/{controller}/{url}/{postUrl}";

            routes.Add(new LowercaseRoute(RouteValues, new RouteValueDictionary(routeOptions), new MvcRouteHandler()));

            // Default route.
            var defaultRouteOptions = new { controller = "blog", action = "index"};
            const string defaultRouteValues = "{action}/{controller}";

            routes.Add(new LowercaseRoute(defaultRouteValues, new RouteValueDictionary(defaultRouteOptions), new MvcRouteHandler()));
        }
    }
}