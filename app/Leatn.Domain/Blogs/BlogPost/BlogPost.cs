namespace Leatn.Domain.Blog.BlogPost
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using BlogPostComment;

    using Shared;

    using Tags;

    #endregion

    /// <summary>
    /// The blog post.
    /// </summary>
    public class BlogPost : AddressableContentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        public BlogPost()
        {
            this.Comments = new Collection<BlogPostComment>();
            this.Tags = new List<Tag>();
        }

        /// <summary>
        /// Gets or sets Blog.
        /// </summary>
        public virtual Blog Blog { get; set; }

        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        /// Gets or sets Comments.
        /// </summary>
        public virtual IList<BlogPostComment> Comments { get; set; }

        /// <summary>
        /// Gets or sets PostDate.
        /// </summary>
        public virtual DateTime PostDate { get; set; }

        public virtual IList<Tag> Tags { get; set; }
    }
}