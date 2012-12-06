namespace Leatn.Domain.Shared
{
    #region Using Directives

    using System;

    using Leatn.Domain.Contracts;

    #endregion

    /// <summary>
    /// The search parameters.
    /// </summary>
    public class SearchParameters : IEmptyAware
    {
        /// <summary>
        /// Gets or sets ContentType.
        /// </summary>
        public SearchContentType ContentType { get; set; }

        /// <summary>
        /// Gets or sets DateFrom.
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Gets or sets DateTo.
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Gets or sets Keywords.
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// The is empty.
        /// </summary>
        /// <returns>
        /// The value indicating whether the model is empty.
        /// </returns>
        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.Keywords) && !this.DateFrom.HasValue && !this.DateTo.HasValue;
        }
    }
}