namespace Leatn.Domain.Blog
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Leatn.Domain.Shared;
    using Leatn.Domain.User;

    #endregion

    /// <summary>
    /// The blog domain model.
    /// </summary>
    public class Blog : AddressableContentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Blog"/> class.
        /// </summary>
        public Blog()
        {
            this.BlogPosts = new List<BlogPost.BlogPost>();
        }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public virtual User Author { get; set; }

        /// <summary>
        /// Gets or sets BlogPosts.
        /// </summary>
        public virtual IList<BlogPost.BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Gets or sets PublishDate.
        /// </summary>
        public virtual DateTime CreationDate { get; set; }
    }
}