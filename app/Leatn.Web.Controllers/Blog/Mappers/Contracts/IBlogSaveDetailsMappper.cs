namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    using Domain.Blog;

    using Framework.Mapper;

    using ViewModels;

    public interface IBlogSaveDetailsMappper : IMapper<BlogFormViewModel, BlogSaveDetails>
    {
    }
}