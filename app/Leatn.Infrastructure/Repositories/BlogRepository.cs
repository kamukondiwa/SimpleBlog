namespace Leatn.Infrastructure.Repositories
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Infrastructure.NHibernate;

    #endregion

    /// <summary>
    /// The blog repository.
    /// </summary>
    public class BlogRepository : LinqRepository<Blog>, IBlogRepository
    {
    }
}