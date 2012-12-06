namespace Leatn.Domain.Shared.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using NHibernate.Validator.Constraints;

    using Tags;

    #endregion

    /// <summary>
    /// The meta data contract.
    /// </summary>
    public interface IMetaData
    {
        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [NotNullNotEmpty]
        [Length(400)]
        string Description { get; set; }

        /// <summary>
        /// Gets or sets Keywords.
        /// </summary>
        [NotNullNotEmpty]
        [Length(400)]
        string Keywords { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [NotNullNotEmpty]
        [Length(100)]
        string Title { get; set; }
    }
}