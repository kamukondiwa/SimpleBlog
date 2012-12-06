namespace Leatn.Domain.User
{
    #region Using Directives

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The user save details.
    /// </summary>
    public class UserSaveDetails : UserSignOnDetails
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [NotNullNotEmpty(Message = "Email must not be empty.")]
        [Email]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Forename.
        /// </summary>
        [NotNullNotEmpty(Message = "Forename must not be empty.")]
        public string Forename { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets Surname.
        /// </summary>
        [NotNullNotEmpty(Message = "Surname must not be empty.")]
        public string Surname { get; set; }
    }
}