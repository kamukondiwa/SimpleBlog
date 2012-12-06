namespace Leatn.Domain.User
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Leatn.Domain.Blog;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The user domain model.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Blogs = new List<Blog>();
        }

        /// <summary>
        /// Gets or sets Blogs.
        /// </summary>
        public virtual IList<Blog> Blogs { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets Forename.
        /// </summary>
        public virtual string Forename { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets PasswordHash.
        /// </summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets PasswordSalt.
        /// </summary>
        public virtual string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets Surname.
        /// </summary>
        public virtual string Surname { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public virtual string Username { get; set; }
    }
}