namespace Leatn.Web.Controllers.Post.Mappers
{
    #region Using Directives

    using System.Linq;

    using Comments.Mappers.Contracts;

    using Contracts;

    using Domain.Blog;
    using Domain.Blog.BlogPost;
    using Domain.Contracts.Services;
    using Domain.Tags;

    using Framework.Extensions;
    using Framework.Mapper;
    using Framework.Traversal;

    using Shared.Mappers.Contracts;

    using ViewModels;

    #endregion

    /// <summary>
    /// The blog post page view model mapper.
    /// </summary>
    public class BlogPostPageViewModelMapper : IBlogPostPageViewModelMapper
    {
        /// <summary>
        /// The archive section view model mapper.
        /// </summary>
        private readonly IArchiveSectionViewModelMapper archiveSectionViewModelMapper;

        /// <summary>
        /// The blog post comment page view model mapper.
        /// </summary>
        private readonly IBlogPostCommentPageViewModelMapper blogPostCommentPageViewModelMapper;

        /// <summary>
        /// The blog post form view model mapper.
        /// </summary>
        private readonly IBlogPostFormViewModelMapper blogPostFormViewModelMapper;

        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostPageViewModelMapper"/> class.
        /// </summary>
        /// <param name="blogPostFormViewModelMapper">
        /// The blog post form view model mapper.
        /// </param>
        /// <param name="blogPostCommentPageViewModelMapper">
        /// The blog Post Comment Page View Model Mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        /// <param name="archiveSectionViewModelMapper">
        /// The archive Section View Model Mapper.
        /// </param>
        public BlogPostPageViewModelMapper(
            IBlogPostFormViewModelMapper blogPostFormViewModelMapper,
            IBlogPostCommentPageViewModelMapper blogPostCommentPageViewModelMapper,
            IIdentityService identityService,
            IArchiveSectionViewModelMapper archiveSectionViewModelMapper)
        {
            this.blogPostFormViewModelMapper = blogPostFormViewModelMapper;
            this.archiveSectionViewModelMapper = archiveSectionViewModelMapper;
            this.blogPostCommentPageViewModelMapper = blogPostCommentPageViewModelMapper;
            this.identityService = identityService;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blog">
        /// The blog to map from.
        /// </param>
        /// <param name="blogPost">
        /// The blog Post.
        /// </param>
        /// <returns>
        /// The blog post page view model.
        /// </returns>
        public BlogPostPageViewModel MapFrom(Blog blog, BlogPost blogPost, Tag tags)
        {
            var blogPostPageViewModel = new BlogPostPageViewModel
                {
                    ShowEditLink = blog.Author.Equals(this.identityService.GetCurrentUser()),
                    BlogUrl = blog.Url,
                    Body = blogPost.Body,
                    Author = blog.Author.Username,
                    PostDate = blogPost.PostDate.ToString("dd MMMM yyyy"),
                    Form = this.blogPostFormViewModelMapper.MapFrom(blogPost),
                    Comments = blogPost.Comments.MapAllUsing(this.blogPostCommentPageViewModelMapper).ToList(),
                    ArchiveSectionViewModel = this.archiveSectionViewModelMapper.MapFrom(blog),
                    Title = blogPost.Title,
                    Url = blogPost.Url,
                };

            blogPost.Tags.ForEach(x => blogPostPageViewModel.AssignedTags.Add("{0}-{1}".FormatWith(x.Name, x.Id)));

            blogPostPageViewModel.Tags = tags;
            return blogPostPageViewModel;
        }
    }
}