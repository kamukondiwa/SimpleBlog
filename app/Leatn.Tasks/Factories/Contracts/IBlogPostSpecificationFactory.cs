namespace Leatn.Tasks.Factories.Contracts
{
    #region Using Directives

    using System;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Blog.BlogPost;

    #endregion

    /// <summary>
    /// The blog post specification factory contract.
    /// </summary>
    public interface IBlogPostSpecificationFactory : ISpecificationFactory<BlogPost>
    {
        /// <summary>
        /// The get lates blog post specificaiton.
        /// </summary>
        /// <returns>
        /// The query specification for the latest blog posts.
        /// </returns>
        ILinqSpecification<BlogPost> GetLatestBlogPostSpecificaiton();

        /// <summary>
        /// The get keyword specification.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The blog post keyword specification.
        /// </returns>
        ILinqSpecification<BlogPost> GetKeywordSpecification(string keywords);

        /// <summary>
        /// The get url specification.
        /// </summary>
        /// <param name="url">
        /// The blog post url.
        /// </param>
        /// <returns>
        /// The blog post by url specification.
        /// </returns>
        ILinqSpecification<BlogPost> GetUrlSpecification(string url);

        /// <summary>
        /// The get date from specification.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <returns>
        /// The blog post specification.
        /// </returns>
        ILinqSpecification<BlogPost> GetDateFromSpecification(DateTime dateFrom);

        /// <summary>
        /// The get date to specification.
        /// </summary>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <returns>
        /// The blog post specification.
        /// </returns>
        ILinqSpecification<BlogPost> GetDateToSpecification(DateTime dateTo);
    }
}