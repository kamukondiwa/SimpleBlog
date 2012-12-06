namespace Leatn.Infrastructure.Repositories
{
    #region Using Directives

    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Domain.Contracts.Specifications;
    using Leatn.Domain.User;
    using Leatn.Infrastructure.NHibernate;

    using Specifications;

    #endregion

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : LinqRepository<User>, IUserRepository
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
        public User FindUserByName(string username)
        {
            var specificaiton = new UsernameSpecification(username);
            return this.FindOne(specificaiton);
        }
    }
}