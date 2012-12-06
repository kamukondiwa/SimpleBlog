namespace Leatn.Tasks.Factories
{
    #region Using Directives

    using System;

    using Domain.Specifications;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Contracts.Specifications;
    using Leatn.Tasks.BlogPost.Specifications;
    using Leatn.Tasks.Factories.Contracts;

    #endregion

    /// <summary>
    /// The blog post specification factory.
    /// </summary>
    public class BlogPostSpecificationFactory : BaseSpecificationFactory<BlogPost>, IBlogPostSpecificationFactory
    {
        /// <summary>
        /// The get date from specification.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <returns>
        /// The blog post specification.
        /// </returns>
        public ILinqSpecification<BlogPost> GetDateFromSpecification(DateTime dateFrom)
        {
            return new BlogPostDateFromSpecification(dateFrom);
        }

        /// <summary>
        /// The get date to specification.
        /// </summary>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <returns>
        /// The blog post specification.
        /// </returns>
        public ILinqSpecification<BlogPost> GetDateToSpecification(DateTime dateTo)
        {
            return new BlogPostDateToSpecification(dateTo);
        }

        /// <summary>
        /// The get keyword specification.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The blog post query specification.
        /// </returns>
        public ILinqSpecification<BlogPost> GetKeywordSpecification(string keywords)
        {
            return new BlogPostKeywordSpecification(keywords);
        }

        /// <summary>
        /// The get lates blog post specificaiton.
        /// </summary>
        /// <returns>
        /// The query specification for the 10 latest blog posts.
        /// </returns>
        public ILinqSpecification<BlogPost> GetLatestBlogPostSpecificaiton()
        {
            return new LatesBlogPostSpecification();
        }

        /// <summary>
        /// The get url specification.
        /// </summary>
        /// <param name="url">
        /// The blog post url.
        /// </param>
        /// <returns>
        /// The blog post by url specification.
        /// </returns>
        public ILinqSpecification<BlogPost> GetUrlSpecification(string url)
        {
            return new AdHocSpecification<BlogPost>(x => x.Url == url, url);
        }
    }
}