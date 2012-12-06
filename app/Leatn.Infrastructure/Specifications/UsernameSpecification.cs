namespace Leatn.Infrastructure.Specifications
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Domain.Specifications;

    using Leatn.Domain.User;

    #endregion

    /// <summary>
    /// The username specification.
    /// </summary>
    public class UsernameSpecification : QuerySpecification<User>
    {
        /// <summary>
        /// The username.
        /// </summary>
        private readonly string username;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameSpecification"/> class.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        public UsernameSpecification(string username)
        {
            this.username = username;
        }

        /// <summary>
        /// Gets MatchingCriteria.
        /// </summary>
        public override Expression<Func<User, bool>> MatchingCriteria
        {
            get
            {
                return x => x.Username.Equals(this.username, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}