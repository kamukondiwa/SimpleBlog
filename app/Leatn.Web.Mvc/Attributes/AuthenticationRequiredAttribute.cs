namespace Leatn.Web.Mvc.Attributes
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    /// <summary>
    /// The authentication required attribute.
    /// </summary>
    public class AuthenticationRequiredAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                this.RedirectToLogin(filterContext.HttpContext);
            }
        }

        /// <summary>
        /// The redirect to login.
        /// </summary>
        /// <param name="httpContext">
        /// The http context.
        /// </param>
        public virtual void RedirectToLogin(HttpContextBase httpContext)
        {
            var redirectOnSuccess = httpContext.Request.Url.AbsolutePath;
            var redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
            var loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
            httpContext.Response.Redirect(loginUrl, true);
        }
    }
}