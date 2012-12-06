namespace Leatn.Tasks.Search
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Domain.Contracts.Services;
    using Leatn.Domain.Shared;
    using Leatn.Tasks.Factories.Contracts;
    using Leatn.Web.Controllers.Search.Contracts;

    #endregion

    /// <summary>
    /// The search tasks.
    /// </summary>
    public class SearchTasks : ISearchTasks
    {
        /// <summary>
        /// The blog post repository.
        /// </summary>
        private readonly IBlogPostRepository blogPostRepository;

        /// <summary>
        /// The blog post specification factory.
        /// </summary>
        private readonly IBlogPostSpecificationFactory blogPostSpecificationFactory;

        /// <summary>
        /// The blog repository.
        /// </summary>
        private readonly IBlogRepository blogRepository;

        /// <summary>
        /// The blog specification builder.
        /// </summary>
        private readonly ILinqSpecificationBuilderService blogSpecificationBuilder;

        /// <summary>
        /// The blog specifications factory.
        /// </summary>
        private readonly IBlogSpecificationFactory blogSpecificationFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTasks"/> class.
        /// </summary>
        /// <param name="blogPostSpecificationFactory">
        /// The blog post specification factory.
        /// </param>
        /// <param name="blogPostRepository">
        /// The blog post repository.
        /// </param>
        /// <param name="blogSpecificationFactory">
        /// The blog Specification Factory.
        /// </param>
        /// <param name="blogRepository">
        /// The blog Repository.
        /// </param>
        /// <param name="blogSpecificationBuilder">
        /// The blog Specification Builder.
        /// </param>
        public SearchTasks(
            IBlogPostSpecificationFactory blogPostSpecificationFactory, 
            IBlogPostRepository blogPostRepository, 
            IBlogSpecificationFactory blogSpecificationFactory, 
            IBlogRepository blogRepository, 
            ILinqSpecificationBuilderService blogSpecificationBuilder)
        {
            this.blogPostSpecificationFactory = blogPostSpecificationFactory;
            this.blogSpecificationBuilder = blogSpecificationBuilder;
            this.blogPostRepository = blogPostRepository;
            this.blogSpecificationFactory = blogSpecificationFactory;
            this.blogRepository = blogRepository;
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The search results.
        /// </returns>
        public IQueryable<AddressableContentBase> Search(SearchParameters parameters)
        {
            if (!parameters.IsEmpty())
            {
                switch (parameters.ContentType)
                {
                    case SearchContentType.Blog:
                        return this.SearchBlogs(parameters);
                    case SearchContentType.Post:
                        return this.SearchBlogPosts(parameters);
                    case SearchContentType.Any:
                        return this.SearchAny(parameters);
                }
            }

            return new List<AddressableContentBase>().AsQueryable();
        }

        /// <summary>
        /// The search any.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The search results.
        /// </returns>
        private IQueryable<AddressableContentBase> SearchAny(SearchParameters parameters)
        {
            var searchResults = new List<AddressableContentBase>();

            searchResults.AddRange(this.SearchBlogs(parameters));
            searchResults.AddRange(this.SearchBlogPosts(parameters));

            return searchResults.AsQueryable();
        }

        /// <summary>
        /// The search blog posts.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The search results.
        /// </returns>
        private IQueryable<AddressableContentBase> SearchBlogPosts(SearchParameters parameters)
        {
            var blogPostKeywordSpecification = this.blogPostSpecificationFactory.GetNullSpecification();

            if (!string.IsNullOrEmpty(parameters.Keywords))
            {
               blogPostKeywordSpecification = this.blogPostSpecificationFactory.GetKeywordSpecification(parameters.Keywords);
            }

            var dateFromSpecification = this.blogPostSpecificationFactory.GetNullSpecification();

            if (parameters.DateFrom.HasValue)
            {
                dateFromSpecification =
                    this.blogPostSpecificationFactory.GetDateFromSpecification(parameters.DateFrom.Value);
            }

            var dateToSpecification = this.blogPostSpecificationFactory.GetNullSpecification();

            if (parameters.DateTo.HasValue)
            {
                dateToSpecification = this.blogPostSpecificationFactory.GetDateToSpecification(parameters.DateTo.Value);
            }

            var searchSpecification = this.blogSpecificationBuilder
                .Using(blogPostKeywordSpecification)
                .And(dateFromSpecification)
                .And(dateToSpecification)
                .ToSpecification();

            return this.blogPostRepository
                .FindAll(searchSpecification)
                .OrderByDescending(x => x.PostDate)
                .Cast<AddressableContentBase>();
        }

        /// <summary>
        /// The search blogs.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The search results.
        /// </returns>
        private IQueryable<AddressableContentBase> SearchBlogs(SearchParameters parameters)
        {
            var keywordSpecification = this.blogSpecificationFactory.GetNullSpecification();

            if (!string.IsNullOrEmpty(parameters.Keywords))
            {
                keywordSpecification = this.blogSpecificationFactory.GetKeywordSpecification(parameters.Keywords);
            }

            var dateFromSpecification = this.blogSpecificationFactory.GetNullSpecification();

            if (parameters.DateFrom.HasValue)
            {
                dateFromSpecification = this.blogSpecificationFactory.GetDateFromSpecification(
                    parameters.DateFrom.Value);
            }

            var dateToSpecification = this.blogSpecificationFactory.GetNullSpecification();

            if (parameters.DateTo.HasValue)
            {
                dateToSpecification = this.blogSpecificationFactory.GetDateToSpecification(parameters.DateTo.Value);
            }

            var searchSpecification = this.blogSpecificationBuilder
                .Using(keywordSpecification)
                .And(dateFromSpecification)
                .And(dateToSpecification)
                .ToSpecification();

            return this.blogRepository
                .FindAll(searchSpecification)
                .OrderByDescending(x => x.CreationDate)
                .Cast<AddressableContentBase>();
        }
    }
}