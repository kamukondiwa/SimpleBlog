namespace Leatn.Framework.Captcha
{
    /// <summary>
    /// The captcha contract.
    /// </summary>
    [Validation.Captcha]
    public interface ICaptcha
    {
        /// <summary>
        /// Gets or sets Captcha.
        /// </summary>
        string Captcha { get; set; }

        /// <summary>
        /// Gets or sets Guid.
        /// </summary>
        string Guid { get; set; }
    }
}