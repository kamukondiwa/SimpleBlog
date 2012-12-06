namespace Leatn.Web.Mvc.Attributes
{
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// The authorization attribute.
    /// </summary>
    public class AuthorizationAttribute : AuthenticationRequiredAttribute
    {
        /// <summary>
        /// The exempt from authorization.
        /// </summary>
        private bool exemptFromAuthorization;

        /// <summary>
        /// The filter context.
        /// </summary>
        private ActionExecutingContext filterContext;

        /// <summary>
        /// Gets or sets Exempt.
        /// </summary>
        public string Exempt { get; set; }

        /// <summary>
        /// The check exemption.
        /// </summary>
        public void CheckExemption()
        {
            if (string.IsNullOrEmpty(this.Exempt))
            {
                return;
            }

            if (!this.Exempt.Contains(','))
            {
                if (this.Exempt.ToLower().Trim() == this.filterContext.RouteData.Values["Action"].ToString().ToLower())
                {
                    this.exemptFromAuthorization = true;
                }
            }

            if (this.Exempt.Contains(','))
            {
                foreach (var action in this.Exempt.ToLower().Split(','))
                {
                    if (action.ToLower().Trim() == this.filterContext.RouteData.Values["Action"].ToString().ToLower())
                    {
                        this.exemptFromAuthorization = true;
                    }
                }
            }
        }

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.filterContext = context;
            this.CheckExemption();

            if (!this.exemptFromAuthorization)
            {
                base.OnActionExecuting(this.filterContext);
            }
        }
    }
}