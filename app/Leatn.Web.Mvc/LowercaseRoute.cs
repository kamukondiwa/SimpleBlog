namespace Leatn.Web.Mvc
{
    #region Using Directives

    using System.Web.Routing;
    using System.Web.Mvc.Resources;

    #endregion

    /// <summary>
    /// The lowercase route.
    /// </summary>
    public class LowercaseRoute : Route
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LowercaseRoute"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="routeHandler">
        /// The route handler.
        /// </param>
        public LowercaseRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LowercaseRoute"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="defaults">
        /// The defaults.
        /// </param>
        /// <param name="routeHandler">
        /// The route handler.
        /// </param>
        public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LowercaseRoute"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="defaults">
        /// The defaults.
        /// </param>
        /// <param name="constraints">
        /// The constraints.
        /// </param>
        /// <param name="routeHandler">
        /// The route handler.
        /// </param>
        public LowercaseRoute(
            string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LowercaseRoute"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="defaults">
        /// The defaults.
        /// </param>
        /// <param name="constraints">
        /// The constraints.
        /// </param>
        /// <param name="dataTokens">
        /// The data tokens.
        /// </param>
        /// <param name="routeHandler">
        /// The route handler.
        /// </param>
        public LowercaseRoute(
            string url, 
            RouteValueDictionary defaults, 
            RouteValueDictionary constraints, 
            RouteValueDictionary dataTokens, 
            IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        /// <summary>
        /// The get virtual path.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="values">
        /// The values.
        /// </param>
        /// <returns>
        /// </returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                path.VirtualPath = path.VirtualPath.ToLowerInvariant();
            }

            return path;
        }
    }
}