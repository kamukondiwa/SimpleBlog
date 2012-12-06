namespace Leatn.Web.Mvc.Extensions
{
    #region Using Directives

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The url helper extensions.
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// The about.
        /// </summary>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <returns>
        /// The about.
        /// </returns>
        public static string About(this UrlHelper urlHelper)
        {
            return urlHelper.Action("about", "blog");
        }

        /// <summary>
        /// The contact.
        /// </summary>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <returns>
        /// The contact.
        /// </returns>
        public static string Contact(this UrlHelper urlHelper)
        {
            return urlHelper.Action("contact", "blog");
        }

        /// <summary>
        /// The content.
        /// </summary>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <param name="relativePath">
        /// The relative path.
        /// </param>
        /// <returns>
        /// The content path.
        /// </returns>
        public static string StaticContent(this UrlHelper urlHelper, string relativePath)
        {
            return string.Format("/content/{0}", relativePath);
        }

        /// <summary>
        /// The create blog.
        /// </summary>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <returns>
        /// The create blog.
        /// </returns>
        public static string CreateBlog(this UrlHelper urlHelper)
        {
            return urlHelper.Action("create", "blog");
        }

        /// <summary>
        /// The create blog post.
        /// </summary>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <param name="blogUrl">
        /// The blog url.
        /// </param>
        /// <returns>
        /// The create blog post.
        /// </returns>
        public static string CreateBlogPost(this UrlHelper urlHelper, string blogUrl)
        {
            return urlHelper.Action("add", "post", new { url = blogUrl });
        }

        /// <summary>
        /// The home.
        /// </summary>
        /// <param name="urlHelper">
        /// The url helper.
        /// </param>
        /// <returns>
        /// The home url.
        /// </returns>
        public static string Home(this UrlHelper urlHelper)
        {
            return urlHelper.Action("index", "blog");
        }
    }
}