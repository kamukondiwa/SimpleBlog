namespace Leatn.Web.Controllers.Search.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Shared;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Search.ViewModels;

    #endregion

    /// <summary>
    /// The search parameter mapper contract.
    /// </summary>
    public interface ISearchParameterMapper : IMapper<SearchFormViewModel, SearchParameters>
    {
    }
}