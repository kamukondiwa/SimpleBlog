namespace Leatn.Tasks.BlogPost.Mappers.Contracts
{
    using Domain.Blog.BlogPost;

    using Framework.Mapper;

    /// <summary>
    /// The blog post mapper contract.
    /// </summary>
    public interface IBlogPostMapper : IEntityMapper<BlogPostSaveDetails, BlogPost>
    {
    }
}