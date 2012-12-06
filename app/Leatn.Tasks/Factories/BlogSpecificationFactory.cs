namespace Leatn.Tasks.Factories
{
    #region Using Directives

    using System;

    using Domain.Specifications;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Blog;
    using Leatn.Domain.Contracts.Specifications;
    using Leatn.Tasks.Blog.Specifications;
    using Leatn.Tasks.Factories.Contracts;

    #endregion

    /// <summary>
    /// The blog specification factory.
    /// </summary>
    public class BlogSpecificationFactory : BaseSpecificationFactory<Blog>, IBlogSpecificationFactory
    {
        /// <summary>
        /// The get blog url specification.
        /// </summary>
        /// <param name="url">
        /// The requested blog's url.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        public ILinqSpecification<Blog> GetBlogUrlSpecification(string url)
        {
            return this.GetAdHocSpecification(x => x.Url == url, url);
        }

        /// <summary>
        /// The get date from specification.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        public ILinqSpecification<Blog> GetDateFromSpecification(DateTime dateFrom)
        {
            return new BlogDateFromSpecification(dateFrom);
        }

        /// <summary>
        /// The get date to specification.
        /// </summary>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        public ILinqSpecification<Blog> GetDateToSpecification(DateTime dateTo)
        {
            return new BlogDateToSpecification(dateTo);
        }

        /// <summary>
        /// The get keyword specification.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        public ILinqSpecification<Blog> GetKeywordSpecification(string keywords)
        {
            return new BlogKeywordSpecification(keywords);
        }

        /// <summary>
        /// The get latest blog specification.
        /// </summary>
        /// <returns>
        /// A blog search specification.
        /// </returns>
        public ILinqSpecification<Blog> GetLatestBlogSpecification()
        {
            return new LatestBlogSpecification();
        }
    }
}