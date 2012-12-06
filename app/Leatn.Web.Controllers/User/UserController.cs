namespace Leatn.Web.Controllers.User
{
    #region Using Directives

    using System.Security;
    using System.Web.Mvc;

    using Domain.Contracts.Tasks;

    using Mappers.Contracts;

    using Mvc.Caching;
    using Mvc.Caching.Contracts;

    using ViewModels;

    using xVal.ServerSide;

    #endregion

    /// <summary>
    /// The user controller.
    /// </summary>
    public class UserController : Controller
    {
        private readonly ICachingProvider cachingProvider;

        /// <summary>
        /// The user save details mapper.
        /// </summary>
        private readonly IUserSaveDetailsMapper userSaveDetailsMapper;

        /// <summary>
        /// The user sign on details mapper.
        /// </summary>
        private readonly IUserSignOnDetailsMapper userSignOnDetailsMapper;

        /// <summary>
        /// The user tasks.
        /// </summary>
        private readonly IUserTasks userTasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userSaveDetailsMapper">
        /// The user save details mapper.
        /// </param>
        /// <param name="userTasks">
        /// The user tasks.
        /// </param>
        /// <param name="cachingProvider">
        /// The caching provider.
        /// </param>
        /// <param name="userSignOnDetailsMapper">
        /// The user Sign On Details Mapper.
        /// </param>
        public UserController(
            IUserSaveDetailsMapper userSaveDetailsMapper,
            IUserTasks userTasks,
            ICachingProvider cachingProvider,
            IUserSignOnDetailsMapper userSignOnDetailsMapper)
        {
            this.userSaveDetailsMapper = userSaveDetailsMapper;
            this.userTasks = userTasks;
            this.cachingProvider = cachingProvider;
            this.userSignOnDetailsMapper = userSignOnDetailsMapper;
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <returns>
        /// The register view result.
        /// </returns>
        [HttpGet]
        public ActionResult Register()
        {
            var userPageViewModel = new UserPageViewModel();
            return this.View(userPageViewModel);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="userPageViewModel">
        /// The user page view model.
        /// </param>
        /// <returns>
        /// The register view result.
        /// </returns>
        [HttpPost]
        public ActionResult Register(UserPageViewModel userPageViewModel)
        {
            var userSaveDetails = this.userSaveDetailsMapper.MapFrom(userPageViewModel.Form);

            try
            {
                this.userTasks.Save(userSaveDetails);
                this.userTasks.SignOn(userSaveDetails);
            }
            catch (RulesException exception)
            {
                exception.AddModelStateErrors(this.ModelState, "form");
                return this.View(userPageViewModel);
            }

            return this.RedirectToAction("index", "blog");
        }

        /// <summary>
        /// The sign off.
        /// </summary>
        /// <returns>
        /// The signoff redirect result.
        /// </returns>
        [HttpGet]
        public ActionResult SignOff()
        {
            this.userTasks.SignOff();
            this.cachingProvider.ResetDependenciesOn(CacheDependencies.GetCurrentUserDependency());
            return this.RedirectToAction("index", "blog");
        }

        /// <summary>
        /// The sign on.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The sign on view result.
        /// </returns>
        [HttpGet]
        public ActionResult SignOn(string returnUrl)
        {
            var model = new UserSignOnPageViewModel { ReturnUrl = returnUrl };
            return this.View(model);
        }

        /// <summary>
        /// The sign on.
        /// </summary>
        /// <param name="userSignOnPageViewModel">
        /// The user sign on page view model.
        /// </param>
        /// <returns>
        /// The sign on view result.
        /// </returns>
        [HttpPost]
        public ActionResult SignOn(UserSignOnPageViewModel userSignOnPageViewModel)
        {
            try
            {
                var signOnDetails = this.userSignOnDetailsMapper.MapFrom(userSignOnPageViewModel.Form);
                this.userTasks.SignOn(signOnDetails);
            }
            catch (RulesException exception)
            {
                exception.AddModelStateErrors(this.ModelState, "form");
                return this.View(userSignOnPageViewModel);
            }
            catch (SecurityException)
            {
                this.ModelState.AddModelError("Form.Username", "Incorrect user credentials.");
                this.ModelState.AddModelError("Form.Password", "Incorrect user credentials.");

                return this.View(userSignOnPageViewModel);
            }

            if (string.IsNullOrEmpty(userSignOnPageViewModel.ReturnUrl))
            {
                return this.RedirectToAction("index", "blog");
            }
            return this.Redirect(userSignOnPageViewModel.ReturnUrl);
        }
    }
}