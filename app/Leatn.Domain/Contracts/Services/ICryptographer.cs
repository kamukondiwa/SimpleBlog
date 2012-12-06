namespace Leatn.Domain.Contracts.Services
{
    /// <summary>
    /// The cryptographer contract.
    /// </summary>
    public interface ICryptographer
    {
        /// <summary>
        /// The create salt.
        /// </summary>
        /// <returns>
        /// The create salt.
        /// </returns>
        string CreateSalt();

        /// <summary>
        /// The compute hash.
        /// </summary>
        /// <param name="valueToHash">
        /// The value to hash.
        /// </param>
        /// <returns>
        /// The compute hash.
        /// </returns>
        string ComputeHash(string valueToHash);

        /// <summary>
        /// The get password hash.
        /// </summary>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="salt">
        /// The salt.
        /// </param>
        /// <returns>
        /// The get password hash.
        /// </returns>
        string GetPasswordHash(string password, string salt);
    }
}