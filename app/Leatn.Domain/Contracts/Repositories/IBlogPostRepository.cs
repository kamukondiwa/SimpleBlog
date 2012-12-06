namespace Leatn.Domain.Contracts.Repositories
{
    using Blog.BlogPost;

    /// <summary>
    /// The blog post repository contract.
    /// </summary>
    public interface IBlogPostRepository : ILinqRepository<BlogPost>
    {
    }
}