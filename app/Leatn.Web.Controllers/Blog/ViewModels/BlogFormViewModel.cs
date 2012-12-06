namespace Leatn.Web.Controllers.Blog.ViewModels
{
    #region Using Directives

    using System;

    using Leatn.Domain;
    using Leatn.Domain.Shared.Contracts;

    using NHibernate.Validator.Constraints;

    #endregion

    /// <summary>
    /// The blog form view model.
    /// </summary>
    public class BlogFormViewModel : ValidatableValueObject, IMetaData
    {
        /// <summary>
        /// Gets or sets PublishDate.
        /// </summary>
        public DateTime CreationDate { get; set; }

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
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [NotNullNotEmpty]
        public string Url { get; set; }
    }
}