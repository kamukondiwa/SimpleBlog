namespace Leatn.Web.Mvc.Exceptions
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// The not found exception.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// The message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public NotFoundException(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Gets Message.
        /// </summary>
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}