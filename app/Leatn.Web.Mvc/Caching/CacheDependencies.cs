namespace Leatn.Web.Mvc.Caching
{
    #region Using Directives

    using Domain.Contracts.Services;

    using Framework.Extensions;

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public static class CacheDependencies
    {
        public static string Web
        {
            get
            {
                return "WebCacheDependency";
            }
        }

        public static string GetCurrentUserDependency()
        {
            var identityService = ServiceLocator.Current.GetInstance<IIdentityService>();
            var currentUser = identityService.GetCurrentUser();
            if (currentUser == null)
            {
                return "Annonymous";
            }

            return "{0}-{1}-{2}-Dependency".FormatWith(currentUser.Id, currentUser.Username, currentUser.Surname);
        }
    }
}