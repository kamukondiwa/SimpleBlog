namespace Leatn.Web.Controllers.User.ViewModels
{
    #region Using Directives

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The user form view model.
    /// </summary>
    public class UserFormViewModel
    {
        /// <summary>
        /// Gets or sets ConfirmationEmail.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
        [Email]
        public string ConfirmationEmail { get; set; }

        /// <summary>
        /// Gets or sets ConfirmationPassword.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
        public string ConfirmationPassword { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
        [Email]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Forename.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
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
        /// Gets or sets Password.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Surname.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        [NotNull(Message = "*")]
        [NotEmpty(Message = "*")]
        public string Username { get; set; }
    }
}