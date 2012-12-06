namespace Leatn.Web.Controllers.Post.Mappers.Contracts
{
    using Domain.Blog.BlogPost;

    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The blog post save details mapper contract.
    /// </summary>
    public interface IBlogPostSaveDetailsMapper : IMapper<BlogPostFormViewModel, BlogPostSaveDetails>
    {
    }
}