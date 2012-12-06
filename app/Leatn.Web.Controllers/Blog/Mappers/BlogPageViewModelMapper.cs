namespace Leatn.Web.Controllers.Blog.Mappers
{
    #region Using Directives

    using System.Linq;

    using AutoMapper;

    using Leatn.Domain.Blog;
    using Leatn.Domain.Contracts.Services;
    using Leatn.Framework.Compareres;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.Mappers.Contracts;
    using Leatn.Web.Controllers.Blog.ViewModels;
    using Leatn.Web.Controllers.Post.Mappers.Contracts;
    using Leatn.Web.Controllers.Shared.Mappers.Contracts;

    #endregion

    /// <summary>
    /// The blog page view model mapper.
    /// </summary>
    public class BlogPageViewModelMapper : BaseMapper<Blog, BlogPageViewModel>, IBlogPageViewModelMapper
    {
        /// <summary>
        /// The blog form view model mapper.
        /// </summary>
        private readonly IBlogFormViewModelMapper blogFormViewModelMapper;

        /// <summary>
        /// The blog post summary page view model mapper.
        /// </summary>
        private readonly IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper;

        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        /// <summary>
        /// The archive section view model mapper.
        /// </summary>
        private readonly IArchiveSectionViewModelMapper archiveSectionViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPageViewModelMapper"/> class.
        /// </summary>
        /// <param name="blogFormViewModelMapper">
        /// The blog form view model mapper.
        /// </param>
        /// <param name="blogPostSummaryPageViewModelMapper">
        /// The blog Post Summary Page View Model Mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        /// <param name="archiveSectionViewModelMapper">
        /// The archive Section View Model Mapper.
        /// </param>
        public BlogPageViewModelMapper(
            IBlogFormViewModelMapper blogFormViewModelMapper, 
            IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper, 
            IIdentityService identityService, 
            IArchiveSectionViewModelMapper archiveSectionViewModelMapper)
        {
            this.blogFormViewModelMapper = blogFormViewModelMapper;
            this.archiveSectionViewModelMapper = archiveSectionViewModelMapper;
            this.identityService = identityService;
            this.blogPostSummaryPageViewModelMapper = blogPostSummaryPageViewModelMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blog">
        /// The blog to map form.
        /// </param>
        /// <returns>
        /// The mapped blog page view model.
        /// </returns>
        public override BlogPageViewModel MapFrom(Blog blog)
        {
            var blogPageViewModel = base.MapFrom(blog);
            blogPageViewModel.CreationDate = blog.CreationDate.ToString("dd MMMM yyyy");
            blogPageViewModel.Author = blog.Author.Username;
            blogPageViewModel.Form = this.blogFormViewModelMapper.MapFrom(blog);
            blogPageViewModel.BlogPosts = blog.BlogPosts
                .MapAllUsing(this.blogPostSummaryPageViewModelMapper)
                .OrderByDescending(x => x.PostDate, new StringDateComparer());

            blogPageViewModel.ShowAddPostLink = this.identityService.IsCurrentUserAuthenticated;

            blogPageViewModel.ShowOtherBlogsLink = blog.Author.Blogs.Count > 1;

            blogPageViewModel.ArchiveSectionViewModel = this.archiveSectionViewModelMapper.MapFrom(blog);

            return blogPageViewModel;
        }

        /// <summary>
        /// The create map.
        /// </summary>
        protected override void CreateMap()
        {
            Mapper.CreateMap<Blog, BlogPageViewModel>().ForMember(x => x.Author, o => o.Ignore()).ForMember(
                x => x.CreationDate, o => o.Ignore()).ForMember(x => x.BlogPosts, o => o.Ignore());
        }
    }
}