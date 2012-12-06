namespace Leatn.Web.Controllers.RSS.Mappers
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Compareres;
    using Leatn.Framework.Extensions;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.RSS.Mappers.Contracts;
    using Leatn.Web.Controllers.RSS.ViewModels;

    #endregion

    /// <summary>
    /// The rss feed view model mapper.
    /// </summary>
    public class RSSFeedViewModelMapper : IRSSFeedViewModelMapper
    {
        /// <summary>
        /// The rss element view model mapper.
        /// </summary>
        private readonly IRSSElementViewModelMapper rssElementViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RSSFeedViewModelMapper"/> class.
        /// </summary>
        /// <param name="rssElementViewModelMapper">
        /// The rss element view model mapper.
        /// </param>
        public RSSFeedViewModelMapper(IRSSElementViewModelMapper rssElementViewModelMapper)
        {
            this.rssElementViewModelMapper = rssElementViewModelMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPosts">
        /// The blogPosts.
        /// </param>
        /// <returns>
        /// The mapped RSS feed view model.
        /// </returns>
        public RSSFeedViewModel MapFrom(IEnumerable<BlogPost> blogPosts)
        {
            var link = "http://{0}/rss".FormatWith(HttpContext.Current.Request.Url.Host);

            var channel = new RssElementViewModel
                {
                    Link = link, 
                    Language = "en-gb",
                    PubDate = DateTime.Now.ToRFC822String(), 
                    Description = "SimpleBlog - latest Blog Posts", 
                    Title = "SimpleBlog", 
                    Copyright = "Copyright {0}, {1}".FormatWith(DateTime.Now.Year, "Kamukondiwa. All rights reserved")
                };

            return new RSSFeedViewModel
                {
                    Channel = channel, 
                    Elements =
                        blogPosts.MapAllUsing(this.rssElementViewModelMapper).OrderByDescending(
                        x => x.PubDate, new StringDateComparer()).ToList()
                };
        }
    }
}