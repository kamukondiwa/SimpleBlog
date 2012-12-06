namespace Leatn.Web.Controllers.Comments.ViewModels
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using Framework.Captcha;
    using Framework.Validation;

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The blog post comment form view model.
    /// </summary>
    public class BlogPostCommentFormViewModel : ICaptcha
    {

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        [NotNullNotEmpty(Message = "Please enter a Body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets Captcha.
        /// </summary>
        public string Captcha { get; set; }

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
        /// Gets or sets Guid.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string PostUrl { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [NotNullNotEmpty(Message = "Please enter a Username")]
        public string Username { get; set; }
    }
}