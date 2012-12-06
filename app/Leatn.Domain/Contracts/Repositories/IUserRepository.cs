namespace Leatn.Domain.Contracts.Repositories
{
    #region Using Directives

    using Leatn.Domain.User;

    #endregion

    /// <summary>
    /// The user repository contract.
    /// </summary
    public interface IUserRepository : ILinqRepository<User>
    {
        /// <summary>
        /// The find one.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// Returns the user matching the specified username.
        /// </returns>
        User FindUserByName(string username);
    }
}