namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.ViewModels;

    #endregion

    /// <summary>
    /// The blog page view model mapper contract.
    /// </summary>
    public interface IBlogPageViewModelMapper : IMapper<Blog, BlogPageViewModel>
    {
    }
}