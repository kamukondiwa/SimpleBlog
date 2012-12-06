namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    using Domain.Blog;

    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The blog form view model mapper contract.
    /// </summary>
    public interface IBlogFormViewModelMapper : IMapper<Blog, BlogFormViewModel>
    {
    }
}