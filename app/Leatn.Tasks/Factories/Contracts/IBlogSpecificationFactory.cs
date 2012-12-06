namespace Leatn.Tasks.Factories.Contracts
{
    #region Using Directives

    using System;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Blog;

    #endregion

    /// <summary>
    /// The blog specifications factory contract.
    /// </summary>
    public interface IBlogSpecificationFactory : ISpecificationFactory<Blog>
    {
        /// <summary>
        /// The get latest blog specification.
        /// </summary>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        ILinqSpecification<Blog> GetLatestBlogSpecification();

        /// <summary>
        /// The get blog url specification.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        ILinqSpecification<Blog> GetBlogUrlSpecification(string url);

        /// <summary>
        /// The get keyword specification.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        ILinqSpecification<Blog> GetKeywordSpecification(string keywords);

        /// <summary>
        /// The get date from specification.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        ILinqSpecification<Blog> GetDateFromSpecification(DateTime dateFrom);

        /// <summary>
        /// The get date to specification.
        /// </summary>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        ILinqSpecification<Blog> GetDateToSpecification(DateTime dateTo);
    }
}