namespace Leatn.Domain.Blog.BlogPost
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using Leatn.Domain.Shared.Contracts;

    using NHibernate.Validator.Constraints;

    using Tags;

    #endregion

    /// <summary>
    /// The blog post save details.
    /// </summary>
    public class BlogPostSaveDetails : ValidatableValueObject, IMetaData
    {
        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        [NotNullNotEmpty]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Keywords.
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Gets or sets PostDate.
        /// </summary>
        public DateTime PostDate { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [NotNullNotEmpty]
        [Length(100)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        public virtual List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [NotNullNotEmpty]
        [Length(50)]
        public string Url { get; set; }
    }
}