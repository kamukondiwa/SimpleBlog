namespace Leatn.Web.Controllers.Post.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Framework.Compareres;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Contracts.Services;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.ViewModels;
    using Leatn.Web.Controllers.Post.Mappers.Contracts;

    #endregion

    /// <summary>
    /// The blog list page view model mapper.
    /// </summary>
    public class BlogPostListPageViewModelMapper : IBlogPostListPageViewModelMapper
    {
        /// <summary>
        /// The blog post summary page view model mapper.
        /// </summary>
        private readonly IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper;

        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostListPageViewModelMapper"/> class.
        /// </summary>
        /// <param name="blogPostSummaryPageViewModelMapper">
        /// The blog summary page view model mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        public BlogPostListPageViewModelMapper(
            IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper, IIdentityService identityService)
        {
            this.blogPostSummaryPageViewModelMapper = blogPostSummaryPageViewModelMapper;
            this.identityService = identityService;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPosts">
        /// The input.
        /// </param>
        /// <returns>
        /// The blog list page view model.
        /// </returns>
        public BlogPostListPageViewModel MapFrom(IEnumerable<BlogPost> blogPosts)
        {
            var blogPostListPageViewModel = new BlogPostListPageViewModel
                {
                    Results = blogPosts.MapAllUsing(this.blogPostSummaryPageViewModelMapper).OrderByDescending(x => x.PostDate, new StringDateComparer()).ToList()
                };

            var currentUser = this.identityService.GetCurrentUser();

            if (currentUser != null && currentUser.Blogs.Count > 0)
            {
                var blog = currentUser.Blogs.First();
                blogPostListPageViewModel.ShowAddPostLink = true;
                blogPostListPageViewModel.BlogUrl = blog.Url;
            }

            return blogPostListPageViewModel;
        }
    }
}