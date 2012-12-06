namespace Leatn.Web.Controllers.Blog
{
    #region Using Directives

    using System.Web.Mvc;

    using Domain.Contracts.Services;
    using Domain.Contracts.Tasks;

    using Framework.Enumerable;

    using Mappers.Contracts;

    using Mvc.Attributes;
    using Mvc.Caching.Contracts;

    using MvcContrib;

    using Post.Mappers.Contracts;

    using Shared.ActionResults;
    using Shared.ViewModels;

    using ViewModels;

    using xVal.ServerSide;

    #endregion

    /// <summary>
    /// The home controller.
    /// </summary>
    [HandleError]
    public class BlogController : Controller
    {
        /// <summary>
        /// The blog page view model mapper.
        /// </summary>
        private readonly IBlogPageViewModelMapper blogPageViewModelMapper;

        /// <summary>
        /// The blog post archive page view model mapper.
        /// </summary>
        private readonly IBlogPostArchivePageViewModelMapper blogPostArchivePageViewModelMapper;

        /// <summary>
        /// The blog list page view model mapper.
        /// </summary>
        private readonly IBlogPostListPageViewModelMapper blogPostListPageViewModelMapper;

        /// <summary>
        /// The blog post tasks.
        /// </summary>
        private readonly IBlogPostTasks blogPostTasks;

        /// <summary>
        /// The blog save details mappper.
        /// </summary>
        private readonly IBlogSaveDetailsMappper blogSaveDetailsMappper;

        /// <summary>
        /// The blog tasks.
        /// </summary>
        private readonly IBlogTasks blogTasks;

        /// <summary>
        /// The blog user page view model mapper.
        /// </summary>
        private readonly IBlogUserPageViewModelMapper blogUserPageViewModelMapper;

        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        private readonly ICachingProvider cachingProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        /// <param name="blogTasks">
        /// The blog tasks.
        /// </param>
        /// <param name="blogPostTasks">
        /// The blog Post Tasks.
        /// </param>
        /// <param name="blogSaveDetailsMappper">
        /// The blog Save Details Mappper.
        /// </param>
        /// <param name="blogPageViewModelMapper">
        /// The blog Page View Model Mapper.
        /// </param>
        /// <param name="blogPostListPageViewModelMapper">
        /// The blog Post List Page View Model Mapper.
        /// </param>
        /// <param name="blogPostArchivePageViewModelMapper">
        /// The blog Post Archive Page View Model Mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        /// <param name="cachingProvider">
        /// The caching provider.
        /// </param>
        /// <param name="blogUserPageViewModelMapper">
        /// The blog User Page View Model Mapper.
        /// </param>
        public BlogController(
            IBlogTasks blogTasks,
            IBlogPostTasks blogPostTasks,
            IBlogSaveDetailsMappper blogSaveDetailsMappper,
            IBlogPageViewModelMapper blogPageViewModelMapper,
            IBlogPostListPageViewModelMapper blogPostListPageViewModelMapper,
            IBlogPostArchivePageViewModelMapper blogPostArchivePageViewModelMapper,
            IIdentityService identityService,
            ICachingProvider cachingProvider,
            IBlogUserPageViewModelMapper blogUserPageViewModelMapper)
        {
            this.blogTasks = blogTasks;
            this.blogUserPageViewModelMapper = blogUserPageViewModelMapper;
            this.identityService = identityService;
            this.cachingProvider = cachingProvider;
            this.blogPostTasks = blogPostTasks;
            this.blogSaveDetailsMappper = blogSaveDetailsMappper;
            this.blogPageViewModelMapper = blogPageViewModelMapper;
            this.blogPostListPageViewModelMapper = blogPostListPageViewModelMapper;
            this.blogPostArchivePageViewModelMapper = blogPostArchivePageViewModelMapper;
        }

        /// <summary>
        /// The about.
        /// </summary>
        /// <returns>
        /// The about view result.
        /// </returns>
        [WebOutputCacheAttrribute(VaryByParam = "*")]
        public ActionResult About()
        {
            return this.View(new PageViewModel());
        }

        /// <summary>
        /// The archive.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <param name="archiveYear">
        /// The archive year.
        /// </param>
        /// <param name="archiveMonth">
        /// The archive month.
        /// </param>
        /// <returns>
        /// The archive page action result.
        /// </returns>
        [WebOutputCacheAttrribute(VaryByParam = "url;archiveYear;archiveMonth")]
        public ActionResult ArchiveByMonth(string url, int archiveYear, string archiveMonth)
        {
            var blogPosts = this.blogTasks.GetArchivedBlogPosts(url, archiveYear, archiveMonth);

            var pageViewModel = this.blogPostArchivePageViewModelMapper.MapFrom(blogPosts);

            return this.View("archive", pageViewModel);
        }

        /// <summary>
        /// The archive.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <param name="archiveYear">
        /// The archive archiveYear.
        /// </param>
        /// <returns>
        /// The archive page action result.
        /// </returns>
        [WebOutputCacheAttrribute(VaryByParam = "url;archiveYear")]
        public ActionResult ArchiveByYear(string url, int archiveYear)
        {
            var blogPosts = this.blogTasks.GetArchivedBlogPosts(url, archiveYear);

            var pageViewModel = this.blogPostArchivePageViewModelMapper.MapFrom(blogPosts);

            return this.View("archive", pageViewModel);
        }

        /// <summary>
        /// The contact.
        /// </summary>
        /// <returns>
        /// The create view result.
        /// </returns>
        [WebOutputCacheAttrribute(VaryByParam = "*")]
        public ActionResult Contact()
        {
            return this.View(new PageViewModel());
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The create view result.
        /// </returns>
        [HttpGet]
        [Authorization]
        public ActionResult Create()
        {
            var model = new BlogPageViewModel();
            return View(model);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="form">
        /// The form View Model.
        /// </param>
        /// <returns>
        /// The create view result.
        /// </returns>
        [HttpPost]
        [Authorization]
        public ActionResult Create(BlogFormViewModel form)
        {
            var blogSaveDetails = this.blogSaveDetailsMappper.MapFrom(form);

            try
            {
                this.blogTasks.Save(blogSaveDetails);
                return this.RedirectToAction(c => c.Read(blogSaveDetails.Url));
            }
            catch (RulesException ex)
            {
                ex.AddModelStateErrors(this.ModelState, "Form");
            }

            return this.RedirectToAction(c => c.Create());
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The Index view result.
        /// </returns>
        [WebOutputCacheAttrribute(VaryByParam = "*")]
        public ActionResult Index()
        {
            var latestBlogPosts = this.blogPostTasks.GetLatestBlogPosts();
            var model = this.blogPostListPageViewModelMapper.MapFrom(latestBlogPosts);
            return View(model);
        }

        /// <summary>
        /// The read action.
        /// </summary>
        /// <param name="url">
        /// The requested blog's url.
        /// </param>
        /// <returns>
        /// The read view result.
        /// </returns>
        [HttpGet]
        [WebOutputCacheAttrribute(VaryByParam = "url")]
        public ActionResult Read(string url)
        {
            var blog = this.blogTasks.GetBlog(url);

            if (blog == null)
            {
                return new NotFoundResult();
            }

            var model = this.blogPageViewModelMapper.MapFrom(blog);

            return View(model);
        }

        /// <summary>
        /// The read user blogs.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The user's blogs.
        /// </returns>
        [HttpGet]
        [WebOutputCacheAttrribute(VaryByParam = "username")]
        public ActionResult ReadUserBlogs(string username)
        {
            var user = cachingProvider.TryGet(username, () => this.identityService.GetUser(username));

            if (user == null)
            {
                return new NotFoundResult();
            }

            var model = this.blogUserPageViewModelMapper.MapFrom(user.Blogs);

            return this.View(model);
        }
    }
}