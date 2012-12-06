namespace Leatn.Framework.Validation
{
    #region Using Directives

    using System;
    using System.Web;

    using Leatn.Framework.Captcha;

    using NHibernate.Validator.Engine;

    using SharpArch.Core;

    #endregion

    /// <summary>
    /// The captcha validator.
    /// </summary>
    public class CaptchaValidator : IValidator
    {
        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="constraintValidatorContext">
        /// The constraint validator context.
        /// </param>
        /// <returns>
        /// The validation result.
        /// </returns>
        public bool IsValid(object value, IConstraintValidatorContext constraintValidatorContext)
        {
            Check.Require(value is ICaptcha, "Captcha Attribute can only be used on type of ICaptcha");
            return Validate(value as ICaptcha);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="form">
        /// The form to be validated.
        /// </param>
        /// <returns>
        /// The validation result.
        /// </returns>
        private static bool Validate(ICaptcha form)
        {
            var image = CaptchaImage.GetCachedCaptcha(form.Guid);

            var actualValue = form.Captcha;
            var expectedValue = image == null
                                    ? String.Empty
                                    : image.Text;

            HttpContext.Current.Cache.Remove(form.Guid);

            if (String.IsNullOrEmpty(actualValue) || String.IsNullOrEmpty(expectedValue) ||
                !String.Equals(actualValue, expectedValue, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}