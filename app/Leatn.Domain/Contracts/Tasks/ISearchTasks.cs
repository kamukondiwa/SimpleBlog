namespace Leatn.Web.Controllers.Search.Contracts
{
    #region Using Directives

    using System.Linq;

    using Leatn.Domain.Shared;

    #endregion

    /// <summary>
    /// The search tasks contract.
    /// </summary>
    public interface ISearchTasks
    {
        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The search results.
        /// </returns>
        IQueryable<AddressableContentBase> Search(SearchParameters parameters);
    }
}