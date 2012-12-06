namespace Leatn.Web.Controllers.Shared.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The archive year view model mapper contract.
    /// </summary>
    public interface IArchiveYearViewModelMapper : IMapper<Blog, int, ArchiveYearViewModel>
    {
    }
}