namespace Leatn.Web.Controllers.Search.Mappers.Contracts
{
    using System.Web.Mvc;

    using Domain.Shared;

    using Framework.Mapper;

    /// <summary>
    /// The search content type select list mapper contract.
    /// </summary>
    public interface ISearchContentTypeSelectListMapper : IMapper<SearchContentType, SelectList>
    {
    }
}