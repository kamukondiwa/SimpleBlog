namespace Leatn.Web.Controllers.Shared.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The archive months view model mapper contract.
    /// </summary>
    public interface IArchiveMonthsViewModelMapper : IMapper<Blog, int, ArchiveMonthViewModel>
    {
    }
}