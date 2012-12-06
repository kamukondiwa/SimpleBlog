namespace Leatn.Web.Controllers.Search.Mappers.Contracts
{
    #region Using Directives

    using System;
    using System.Web.Mvc;

    using Leatn.Domain.Shared;

    #endregion

    /// <summary>
    /// The search content type select list mapper.
    /// </summary>
    public class SearchContentTypeSelectListMapper : ISearchContentTypeSelectListMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="contentType">
        /// The content type.
        /// </param>
        /// <returns>
        /// The mapped select list.
        /// </returns>
        public SelectList MapFrom(SearchContentType contentType)
        {
            return new SelectList(contentType.ToList(), contentType);
        }
    }
}