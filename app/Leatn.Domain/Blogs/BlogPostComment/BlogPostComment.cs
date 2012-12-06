namespace Leatn.Domain.Blog.BlogPostComment
{
    #region Using Directives

    using System;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The blog post comment.
    /// </summary>
    public class BlogPostComment : Entity
    {
        /// <summary>
        /// Gets or sets BlogPost.
        /// </summary>
        public virtual BlogPost.BlogPost BlogPost { get; set; }

        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        /// Gets or sets CommentDate.
        /// </summary>
        public virtual DateTime CommentDate { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public virtual string Username { get; set; }
    }
}