namespace Leatn.Web.Controllers.RSS.Mappers
{
    #region Using Directives

    using System.Globalization;
    using System.Web;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Extensions;
    using Leatn.Web.Controllers.RSS.Mappers.Contracts;
    using Leatn.Web.Controllers.RSS.ViewModels;

    #endregion

    /// <summary>
    /// The rss element view model mapper.
    /// </summary>
    public class RssElementViewModelMapper : IRSSElementViewModelMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPost">
        /// The blogPost.
        /// </param>
        /// <returns>
        /// The mapped rss element view model.
        /// </returns>
        public RssElementViewModel MapFrom(BlogPost blogPost)
        {
            var link = "http://{0}/read/post/{1}/{2}".FormatWith(HttpContext.Current.Request.Url.Host, blogPost.Blog.Url, blogPost.Url);
           
            return new RssElementViewModel
                {
                    Link = link,
                    PubDate = blogPost.PostDate.ToRFC822String(), 
                    Description = blogPost.Description, 
                    Title = blogPost.Title
                };
        }
    }
}