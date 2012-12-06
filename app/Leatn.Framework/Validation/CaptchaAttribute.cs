namespace Leatn.Framework.Validation
{
    #region Using Directives

    using System;

    using NHibernate.Validator.Engine;

    #endregion

    /// <summary>
    /// The captcha attribute.
    /// </summary>
    [ValidatorClass(typeof(CaptchaValidator))]
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class CaptchaAttribute : Attribute, IRuleArgs
    {
        /// <summary>
        /// The message.
        /// </summary>
        private string message = "Please enter the code displayed correctly.";

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }
    }
}