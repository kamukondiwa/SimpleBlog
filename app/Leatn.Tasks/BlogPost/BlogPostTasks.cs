namespace Leatn.Tasks.BlogPost
{
    #region Using Directives

    using System.Linq;

    using Domain.Blog.BlogPost;
    using Domain.Contracts.Repositories;
    using Domain.Contracts.Tasks;

    using Factories.Contracts;

    using Framework.Enumerable;

    using Web.Mvc.Caching.Contracts;

    #endregion

    /// <summary>
    /// The blog post tasks.
    /// </summary>
    public class BlogPostTasks : IBlogPostTasks
    {
        /// <summary>
        /// The blog post repository.
        /// </summary>
        private readonly IBlogPostRepository blogPostRepository;

        /// <summary>
        /// The blog post specification factory.
        /// </summary>
        private readonly IBlogPostSpecificationFactory blogPostSpecificationFactory;

        private readonly ICachingProvider cachingProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostTasks"/> class.
        /// </summary>
        /// <param name="blogPostSpecificationFactory">
        /// The blog post specification factory.
        /// </param>
        /// <param name="blogPostRepository">
        /// The blog post repository.
        /// </param>
        /// <param name="cachingProvider">
        /// The caching provider.
        /// </param>
        public BlogPostTasks(
            IBlogPostSpecificationFactory blogPostSpecificationFactory,
            IBlogPostRepository blogPostRepository,
            ICachingProvider cachingProvider)
        {
            this.blogPostSpecificationFactory = blogPostSpecificationFactory;
            this.blogPostRepository = blogPostRepository;
            this.cachingProvider = cachingProvider;
        }

        /// <summary>
        /// The get latest blog posts.
        /// </summary>
        /// <returns>
        /// The 10 latest blog posts.
        /// </returns>
        public IQueryable<BlogPost> GetLatestBlogPosts()
        {
            var specification = this.blogPostSpecificationFactory.GetLatestBlogPostSpecificaiton();
            return this.cachingProvider.TryGet(
                specification.CacheKey, () => this.blogPostRepository.FindAll(specification).ToConctreteQueryable());
        }
    }
}