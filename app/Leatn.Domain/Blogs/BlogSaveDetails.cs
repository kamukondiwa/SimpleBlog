namespace Leatn.Domain.Blog
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using Leatn.Domain.Shared.Contracts;

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The blog save details.
    /// </summary>
    public class BlogSaveDetails : ValidatableValueObject, IMetaData
    {
        /// <summary>
        /// Gets or sets PublishDate.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [NotNullNotEmpty]
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
        /// Gets or sets Title.
        /// </summary>
        [NotNullNotEmpty]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        public virtual IList<Tags.Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [NotNullNotEmpty]
        public string Url { get; set; }
    }
}