namespace Leatn.Web.Controllers.Post.ViewModels
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using Domain.Shared.Contracts;
    using Domain.Tags;

    using Leatn.Domain;

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The blog post form view model.
    /// </summary>
    public class BlogPostFormViewModel : ValidatableValueObject, IMetaData
    {
        public BlogPostFormViewModel()
        {
            this.Tags = new List<string>();
        }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }

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
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [NotNullNotEmpty]
        [Length(50)]
        public string Url { get; set; }
    }
}