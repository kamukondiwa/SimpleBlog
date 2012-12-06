namespace Leatn.Web.Controllers.User.ViewModels
{
    #region Using Directives

    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The user sign on page view model.
    /// </summary>
    public class UserSignOnPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSignOnPageViewModel"/> class.
        /// </summary>
        public UserSignOnPageViewModel()
        {
            this.Form = new UserSignOnFormViewModel();
        }

        /// <summary>
        /// Gets or sets Form.
        /// </summary>
        public UserSignOnFormViewModel Form { get; set; }

        /// <summary>
        /// Gets or sets ReturnUrl.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}