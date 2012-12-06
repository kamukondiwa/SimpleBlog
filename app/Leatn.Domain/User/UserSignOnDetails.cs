namespace Leatn.Domain.User
{
    using NHibernate.Validator.Constraints;

    /// <summary>
    /// The user sign on details.
    /// </summary>
    public class UserSignOnDetails : ValidatableValueObject
    {
        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [NotNullNotEmpty(Message = "Password must not be empty.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        [NotNullNotEmpty(Message = "Username must not be empty.")]
        public string Username { get; set; }
    }
}