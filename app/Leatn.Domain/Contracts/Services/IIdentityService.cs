namespace Leatn.Domain.Contracts.Services
{
    #region Using Directives

    using Leatn.Domain.User;

    #endregion

    /// <summary>
    /// The identity service contract.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Gets AuthenticationService.
        /// </summary>
        ICryptographer AuthenticationService { get; }

        /// <summary>
        /// Gets a value indicating whether the current user is authenticated.
        /// </summary>
        bool IsCurrentUserAuthenticated { get; }

        /// <summary>
        /// The sign on.
        /// </summary>
        /// <param name="userSignOnDetails">
        /// The user sign on details.
        /// </param>
        void SignOn(UserSignOnDetails userSignOnDetails);

        /// <summary>
        /// The sign off.
        /// </summary>
        void SignOff();

        /// <summary>
        /// The authenticate user.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        /// <returns>
        /// The authenticate user result.
        /// </returns>
        bool AuthenticateUser(UserSignOnDetails credentials);

        /// <summary>
        /// The get current user.
        /// </summary>
        /// <returns>
        /// The currently signed on user.
        /// </returns>
        User GetCurrentUser();

        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// A user matching the specified username.
        /// </returns>
        User GetUser(string username);
    }
}