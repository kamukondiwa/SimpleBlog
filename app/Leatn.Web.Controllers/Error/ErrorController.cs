namespace Leatn.Web.Controllers.Error
{
    #region Using Directives

    using System.Web.Mvc;

    using Leatn.Web.Controllers.Error.ViewModels;

    #endregion

    /// <summary>
    /// error controller.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Action that deals with Unhandled Server Exceptions
        /// </summary>
        /// <returns>
        /// Unhandled Error View.
        /// </returns>
        public ActionResult Error()
        {
            this.Response.StatusCode = 500;
            this.Response.StatusDescription = "Internal Server Error";
            this.Response.TrySkipIisCustomErrors = true;

            return this.View(new ErrorPageViewModel());
        }

        /// <summary>
        /// The invalid input.
        /// </summary>
        /// <returns>
        /// </returns>
        public ActionResult InvalidInput()
        {
            this.Response.StatusCode = 400;
            this.Response.StatusDescription = "Bad Request";
            this.Response.TrySkipIisCustomErrors = true;

            return this.View(new ErrorPageViewModel());
        }

        /// <summary>
        /// Not found action.
        /// </summary>
        /// <returns>
        /// Not found view
        /// </returns>
        public ActionResult NotFound()
        {
            this.Response.StatusCode = 404;
            this.Response.StatusDescription = "Not Found";
            this.Response.TrySkipIisCustomErrors = true;

            return this.View(new ErrorPageViewModel());
        }
    }
}