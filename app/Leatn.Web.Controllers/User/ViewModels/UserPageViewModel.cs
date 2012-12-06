namespace Leatn.Web.Controllers.User.ViewModels
{
    using Shared.ViewModels;

    /// <summary>
    /// The user page view model.
    /// </summary>
    public class UserPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPageViewModel"/> class.
        /// </summary>
        public UserPageViewModel()
        {
            this.Form = new UserFormViewModel { IsActive = true };
        }

        /// <summary>
        /// Gets or sets Form.
        /// </summary>
        public UserFormViewModel Form { get; set; }
    }
}