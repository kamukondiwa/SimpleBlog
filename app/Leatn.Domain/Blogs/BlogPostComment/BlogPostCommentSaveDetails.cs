namespace Leatn.Domain.Blog.BlogPostComment
{
    #region Using Directives

    using System;

    using Framework.Captcha;
    using Framework.Validation;

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The blog post comment save details.
    /// </summary>
    /// [Captcha]
    public class BlogPostCommentSaveDetails : ValidatableValueObject, ICaptcha
    {
        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        [NotNullNotEmpty(Message = "Please enter a Body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets CommentDate.
        /// </summary>
        public DateTime CommentDate { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Email, NotNullNotEmpty(Message = "Please enter an Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string PostUrl { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        [NotNullNotEmpty(Message = "Please enter a Username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Captcha.
        /// </summary>
        public string Captcha { get; set; }

        /// <summary>
        /// Gets or sets Guid.
        /// </summary>
        public string Guid { get; set; }
    }
}