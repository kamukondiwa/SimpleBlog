namespace Leatn.Web.Controllers.Search.Mappers
{
    #region Using Directives

    using Domain.Shared;

    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Search.Mappers.Contracts;
    using Leatn.Web.Controllers.Search.ViewModels;

    #endregion

    /// <summary>
    /// The search parameter mapper.
    /// </summary>
    public class SearchParameterMapper : BaseMapper<SearchFormViewModel, SearchParameters>, ISearchParameterMapper
    {
    }
}