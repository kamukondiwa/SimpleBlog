namespace Leatn.Web.Controllers.Search.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Domain.Shared;
    using Leatn.Framework.Mapper;
    using Leatn.Tasks.Factories.Contracts;
    using Leatn.Web.Controllers.Search.ViewModels;

    #endregion

    /// <summary>
    /// The search result view model mapper.
    /// </summary>
    public class SearchResultViewModelMapper : BaseMapper<AddressableContentBase, SearchResultViewModel>,
                                               ISearchResultViewModelMapper
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
        /// Initializes a new instance of the <see cref="SearchResultViewModelMapper"/> class.
        /// </summary>
        /// <param name="blogPostRepository">
        /// The blog post repository.
        /// </param>
        /// <param name="blogPostSpecificationFactory">
        /// The blog Post Specification Factory.
        /// </param>
        public SearchResultViewModelMapper(
            IBlogPostRepository blogPostRepository, IBlogPostSpecificationFactory blogPostSpecificationFactory)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostSpecificationFactory = blogPostSpecificationFactory;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="addressableContent">
        /// The addressable content.
        /// </param>
        /// <returns>
        /// The mapped search result view model.
        /// </returns>
        public override SearchResultViewModel MapFrom(AddressableContentBase addressableContent)
        {
            var searchResultViewmodel = base.MapFrom(addressableContent);

            if (addressableContent is BlogPost)
            {
                var blogPost = this.blogPostRepository.FindOne(this.blogPostSpecificationFactory.GetUrlSpecification(addressableContent.Url));
                searchResultViewmodel.BlogUrl = blogPost.Blog.Url;
            }

            return searchResultViewmodel;
        }
    }
}