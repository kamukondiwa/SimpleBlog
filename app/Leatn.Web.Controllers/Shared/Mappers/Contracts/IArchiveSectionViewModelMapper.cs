namespace Leatn.Web.Controllers.Shared.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The archive section view model mapper contract.
    /// </summary>
    public interface IArchiveSectionViewModelMapper : IMapper<Blog, ArchiveSectionViewModel>
    {
    }
}