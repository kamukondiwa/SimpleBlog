namespace Leatn.Web.Mvc.Attributes
{
    #region Using Directives

    using System.Web;
    using System.Web.Mvc;

    using Caching;
    using Caching.Contracts;

    using Framework.Extensions;

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public class WebOutputCacheAttrribute : OutputCacheAttribute
    {
        private const string Authenticated = "Authenticated";

        private const string DefaultCacheProfile = "Default";

        private const string IsAuthenticated = "IsAuthenticated";

        private readonly ICachingProvider cachingProvider;

        public WebOutputCacheAttrribute()
        {
            this.cachingProvider = ServiceLocator.Current.GetInstance<ICachingProvider>();
        }

        public static string GetVaryByCustomString(HttpContext context, string custom)
        {
            return VaryByAuthentication(custom, context);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(this.VaryByCustom))
            {
                this.VaryByCustom = IsAuthenticated;
            }
            if (string.IsNullOrEmpty(this.CacheProfile))
            {
                this.CacheProfile = DefaultCacheProfile;
            }

            this.AddPageDependencyTo(filterContext);

            base.OnResultExecuting(filterContext);
        }

        protected virtual void AddPageDependencyTo(ResultExecutingContext filterContext)
        {
            this.cachingProvider.AddDependencyTo(CacheDependencies.Web);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                this.cachingProvider.AddDependencyTo(CacheDependencies.GetCurrentUserDependency());
            }
        }

        private static string VaryByAuthentication(string custom, HttpContext context)
        {
            if (custom == IsAuthenticated && context.User.Identity.IsAuthenticated)
            {
                return CacheDependencies.GetCurrentUserDependency();
            }

            return custom;
        }
    }
}