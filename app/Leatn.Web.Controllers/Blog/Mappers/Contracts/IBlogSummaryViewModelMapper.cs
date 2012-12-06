namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    using Domain.Blog;

    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The blog summary view model mapper contract.
    /// </summary>
    public interface IBlogSummaryViewModelMapper : IMapper<Blog, BlogSummaryViewModel>
    {
    }
}