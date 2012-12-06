namespace Leatn.Domain.Contracts.Repositories
{
    #region Using Directives

    using Leatn.Domain.Blog;

    #endregion

    /// <summary>
    /// The blog repository contract.
    /// </summary>
    public interface IBlogRepository : ILinqRepository<Blog>
    {
    }
}