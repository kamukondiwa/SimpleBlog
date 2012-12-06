namespace Leatn.Domain.Contracts.Tasks
{
    #region Using Directives

    using Leatn.Domain.User;

    #endregion

    /// <summary>
    /// The user tasks contract.
    /// </summary>
    public interface IUserTasks
    {
        /// <summary>
        /// The user save.
        /// </summary>
        /// <param name="userSaveDetails">
        /// The user save details.
        /// </param>
        void Save(UserSaveDetails userSaveDetails);

        /// <summary>
        /// The sign on.
        /// </summary>
        /// <param name="signOnDetails">
        /// The sign on form view model.
        /// </param>
        void SignOn(UserSignOnDetails signOnDetails);

        /// <summary>
        /// The user exists.
        /// </summary>
        /// <param name="userSignOnDetails">
        /// The user sign on details.
        /// </param>
        /// <returns>
        /// The user exists result.
        /// </returns>
        bool UserExists(UserSignOnDetails userSignOnDetails);

        /// <summary>
        /// The sign off.
        /// </summary>
        void SignOff();
    }
}