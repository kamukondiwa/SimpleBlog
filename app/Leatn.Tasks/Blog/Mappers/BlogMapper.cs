namespace Leatn.Tasks.Blog.Mappers
{
    using Contracts;

    using Domain.Blog;

    using Framework.Mapper;

    /// <summary>
    /// The blog mapper.
    /// </summary>
    public class BlogMapper : BaseMapper<BlogSaveDetails, Blog>, IBlogMapper
    {
    }
}