namespace Leatn.Tasks.Blog.Mappers.Contracts
{
    using Domain.Blog;

    using Framework.Mapper;

    /// <summary>
    /// The blog mapper contract.
    /// </summary>
    public interface IBlogMapper : IMapper<BlogSaveDetails, Blog>
    {
    }
}