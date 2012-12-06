namespace Leatn.Tasks.Services
{
    #region Using Directives

    using System;
    using System.Web;
    using System.Web.Security;

    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Domain.Contracts.Services;
    using Leatn.Domain.User;

    #endregion

    /// <summary>
    /// The identity service.
    /// </summary>
    public class IdentityService : IIdentityService
    {
        /// <summary>
        /// The cryptographer.
        /// </summary>
        private readonly ICryptographer cryptographer;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="cryptographer">
        /// The cryptographer.
        /// </param>
        public IdentityService(IUserRepository userRepository, ICryptographer cryptographer)
        {
            this.userRepository = userRepository;
            this.cryptographer = cryptographer;
        }

        /// <summary>
        /// Gets AuthenticationService.
        /// </summary>
        public ICryptographer AuthenticationService
        {
            get
            {
                return this.cryptographer;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current user is authenticated.
        /// </summary>
        public bool IsCurrentUserAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        /// <summary>
        /// The authenticate user.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        /// <returns>
        /// The authenticate user result.
        /// </returns>
        public bool AuthenticateUser(UserSignOnDetails credentials)
        {
            var user = this.userRepository.FindUserByName(credentials.Username);

            if (user == null)
            {
                return false;
            }

            var passwordHash = this.AuthenticationService.GetPasswordHash(credentials.Password, user.PasswordSalt);

            return passwordHash.Equals(user.PasswordHash) && user.IsActive;
        }

        /// <summary>
        /// The get current user.
        /// </summary>
        /// <returns>
        /// The currently signed on user.
        /// </returns>
        public User GetCurrentUser()
        {
            var username = HttpContext.Current.User.Identity.Name;
            return this.userRepository.FindUserByName(username);
        }

        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// A user matching the specified username.
        /// </returns>
        public User GetUser(string username)
        {
            return this.userRepository.FindUserByName(username);
        }

        /// <summary>
        /// The sign off.
        /// </summary>
        public void SignOff()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// The sign on.
        /// </summary>
        /// <param name="userSignOnDetails">
        /// The user sign on details.
        /// </param>
        public void SignOn(UserSignOnDetails userSignOnDetails)
        {
            FormsAuthentication.RedirectFromLoginPage(userSignOnDetails.Username, false);
        }
    }
}