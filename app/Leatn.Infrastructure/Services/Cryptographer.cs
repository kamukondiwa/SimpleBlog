namespace Leatn.Infrastructure.Services
{
    #region Using Directives

    using System;
    using System.Security.Cryptography;
    using System.Text;

    using Domain.Contracts.Services;

    #endregion

    /// <summary>
    /// The cryptographer.
    /// </summary>
    public class Cryptographer : ICryptographer
    {
        /// <summary>
        /// Create a password hash based on a password and salt.  
        /// Adapted from: http://davidhayden.com/blog/dave/archive/2004/02/16/157.aspx
        /// </summary>
        /// <param name="valueToHash">
        /// The value To Hash.
        /// </param>
        /// <returns>
        /// The compute hash.
        /// </returns>
        public string ComputeHash(string valueToHash)
        {
            HashAlgorithm algorithm = SHA512.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(valueToHash));

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Create salt for encrypting user passwords.  
        /// Original Source: http://davidhayden.com/blog/dave/archive/2004/02/16/157.aspx
        /// </summary>
        /// <returns>
        /// The create salt.
        /// </returns>
        public string CreateSalt()
        {
            const int size = 64;

            // Generate a cryptographic random number.
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

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
        public string GetPasswordHash(string password, string salt)
        {
            return this.ComputeHash(password + salt);
        }
    }
}