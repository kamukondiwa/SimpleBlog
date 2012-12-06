namespace Leatn.Infrastructure.Repositories
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Infrastructure.NHibernate;

    #endregion

    /// <summary>
    /// The blog post repository.
    /// </summary>
    public class BlogPostRepository : LinqRepository<BlogPost>, IBlogPostRepository
    {
    }
}