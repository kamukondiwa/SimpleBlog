namespace Leatn.Domain.Shared
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The domain enum extensions.
    /// </summary>
    public static class DomainEnumExtensions
    {
        /// <summary>
        /// The to list.
        /// </summary>
        /// <param name="searchContentType">
        /// The search content type.
        /// </param>
        /// <returns>
        /// Returns a list containing all the Search Content Types.
        /// </returns>
        public static IEnumerable<SearchContentType> ToList(this SearchContentType searchContentType)
        {
            return new[] { SearchContentType.Any, SearchContentType.Blog, SearchContentType.Post };
        }
    }
}