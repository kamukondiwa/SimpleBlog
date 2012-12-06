namespace Leatn.Web.Controllers.Blog.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Framework.Enumerable;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Compareres;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.Mappers.Contracts;
    using Leatn.Web.Controllers.Blog.ViewModels;
    using Leatn.Web.Controllers.Post.Mappers.Contracts;
    using Leatn.Web.Controllers.Shared.Mappers.Contracts;

    #endregion

    /// <summary>
    /// The blog post archive page view model mapper.
    /// </summary>
    public class BlogPostArchivePageViewModelMapper : IBlogPostArchivePageViewModelMapper
    {
        /// <summary>
        /// The archive section view model mapper.
        /// </summary>
        private readonly IArchiveSectionViewModelMapper archiveSectionViewModelMapper;

        /// <summary>
        /// The blog post summary page view model mapper.
        /// </summary>
        private readonly IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostArchivePageViewModelMapper"/> class.
        /// </summary>
        /// <param name="blogPostSummaryPageViewModelMapper">
        /// The blog post summary page view model mapper.
        /// </param>
        /// <param name="archiveSectionViewModelMapper">
        /// The archive Section View Model Mapper.
        /// </param>
        public BlogPostArchivePageViewModelMapper(
            IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper,
            IArchiveSectionViewModelMapper archiveSectionViewModelMapper)
        {
            this.blogPostSummaryPageViewModelMapper = blogPostSummaryPageViewModelMapper;
            this.archiveSectionViewModelMapper = archiveSectionViewModelMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPosts">
        /// The input.
        /// </param>
        /// <returns>
        /// The mapped blog post archive page view model.
        /// </returns>
        public BlogPostArchivePageViewModel MapFrom(IEnumerable<BlogPost> blogPosts)
        {
            var model = new BlogPostArchivePageViewModel
                {
                    Results = blogPosts
                    .MapAllUsing(this.blogPostSummaryPageViewModelMapper)
                    .OrderByDescending(x => x.PostDate, new StringDateComparer()).ToList()
                };

            if (!blogPosts.IsNullOrEmpty())
            {
                var blog = blogPosts.First().Blog;
                model.ArchiveSectionViewModel = this.archiveSectionViewModelMapper.MapFrom(blog);
            }

            return model;
        }
    }
}