namespace Leatn.Domain.Shared
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Contracts;

    using SharpArch.Core.DomainModel;

    using Tags;

    #endregion

    /// <summary>
    /// The addressable content base.
    /// </summary>
    public abstract class AddressableContentBase : Entity, IMetaData
    {
        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets Keywords.
        /// </summary>
        public virtual string Keywords { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [DomainSignature]
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [DomainSignature]
        public virtual string Url { get; set; }
    }
}