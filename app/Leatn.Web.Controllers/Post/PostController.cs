namespace Leatn.Web.Controllers.Post
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Castle.Core.Resource;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Domain.Contracts.Services;
    using Leatn.Domain.Contracts.Tasks;
    using Leatn.Web.Controllers.Comments.Mappers.Contracts;
    using Leatn.Web.Controllers.Comments.ViewModels;
    using Leatn.Web.Controllers.Post.Mappers.Contracts;
    using Leatn.Web.Controllers.Post.ViewModels;
    using Leatn.Web.Controllers.Shared.ActionResults;
    using Leatn.Web.Mvc.Attributes;

    using Mvc.Caching.Contracts;

    using MvcContrib;
    using MvcContrib.Attributes;

    using xVal.ServerSide;

    #endregion

    /// <summary>
    /// The post controller.
    /// </summary>
    public class PostController : Controller
    {
        /// <summary>
        /// The blog post comment save details mapper.
        /// </summary>
        private readonly IBlogPostCommentSaveDetailsMapper blogPostCommentSaveDetailsMapper;

        /// <summary>
        /// The blog post page view model mapper.
        /// </summary>
        private readonly IBlogPostPageViewModelMapper blogPostPageViewModelMapper;

        /// <summary>
        /// The blog post save details mapper.
        /// </summary>
        private readonly IBlogPostSaveDetailsMapper blogPostSaveDetailsMapper;

        /// <summary>
        /// The blog tasks.
        /// </summary>
        private readonly IBlogTasks blogTasks;

        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        private readonly ICachingProvider cachingProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="blogTasks">
        /// The blog tasks.
        /// </param>
        /// <param name="blogPostSaveDetailsMapper">
        /// The blog post save details mapper.
        /// </param>
        /// <param name="blogPostPageViewModelMapper">
        /// The blog post page view model mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        /// <param name="blogPostCommentSaveDetailsMapper">
        /// The blog Post Comment Save Details Mapper.
        /// </param>
        /// <param name="cachingProvider">
        /// The caching provider.
        /// </param>
        public PostController(
            IBlogTasks blogTasks, 
            IBlogPostSaveDetailsMapper blogPostSaveDetailsMapper, 
            IBlogPostPageViewModelMapper blogPostPageViewModelMapper, 
            IIdentityService identityService,
            IBlogPostCommentSaveDetailsMapper blogPostCommentSaveDetailsMapper, ICachingProvider cachingProvider)
        {

            this.blogTasks = blogTasks;
            this.cachingProvider = cachingProvider;
            this.blogPostSaveDetailsMapper = blogPostSaveDetailsMapper;
            this.blogPostPageViewModelMapper = blogPostPageViewModelMapper;
            this.identityService = identityService;
            this.blogPostCommentSaveDetailsMapper = blogPostCommentSaveDetailsMapper;
        }

        /// <summary>
        /// The blog post.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <returns>
        /// The blog post view page model.
        /// </returns>
        [HttpGet]
        [Authorization]
        public ActionResult Add(string url)
        {
            try
            {
                return this.View("edit", this.BlogPostView(url, string.Empty));
            }
            catch (ResourceException)
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// The comment.
        /// </summary>
        /// <param name="commentForm">
        /// The blog post page view model.
        /// </param>
        /// <returns>
        /// The redirect result to the read blog post page.
        /// </returns>
        [HttpPost]
        public ActionResult Comment(BlogPostCommentFormViewModel commentForm)
        {
            var blog = this.blogTasks.GetBlog(commentForm.BlogUrl);

            if (blog == null)
            {
                return new NotFoundResult();
            }

            try
            {
                var blogPostCommentSaveDetails = this.blogPostCommentSaveDetailsMapper.MapFrom(commentForm);
                this.blogTasks.Save(blog, blogPostCommentSaveDetails);
            }
            catch (RulesException ex)
            {
                ex.AddModelStateErrors(this.ModelState, "CommentForm");

                var model = this.BlogPostView(commentForm.BlogUrl, commentForm.PostUrl);
                model.CommentForm = commentForm;

                return this.View("read", model);
            }

            return this.RedirectToAction(x => x.Read(commentForm.BlogUrl, commentForm.PostUrl));
        }

        /// <summary>
        /// The blog post.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <param name="postUrl">
        /// The post url.
        /// </param>
        /// <returns>
        /// The blog post view page model.
        /// </returns>
        [HttpGet]
        [Authorization]
        public ActionResult Edit(string url, string postUrl)
        {
            var blog = this.blogTasks.GetBlog(url);

            var currentUserIsAuthor = blog.Author.Equals(this.identityService.GetCurrentUser());

            if (!currentUserIsAuthor)
            {
                return new NotFoundResult();
            }

            try
            {
                return this.View(this.BlogPostView(url, postUrl));
            }
            catch (ResourceException)
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// The blog post.
        /// </summary>
        /// <param name="form">
        /// The blog post form.
        /// </param>
        /// <returns>
        /// The redirect result to read action.
        /// </returns>
        [HttpPost]
        [Authorization]
        [ValidateInput(false)]
        public ActionResult Edit(BlogPostFormViewModel form)
        {
            var blog = this.blogTasks.GetBlog(form.BlogUrl);

            if (blog == null)
            {
                return new NotFoundResult();
            }

            try
            {
                var postSaveDetails = this.blogPostSaveDetailsMapper.MapFrom(form);
                this.blogTasks.Save(blog, postSaveDetails);
                return this.RedirectToAction(x => x.Read(form.BlogUrl, form.Url));
            }
            catch (RulesException ex)
            {
                ex.AddModelStateErrors(this.ModelState, "Form");
            }

            var model = this.BlogPostView(form.BlogUrl, string.Empty);
            model.Form = form;

            return this.View(model);
        }

        /// <summary>
        /// The read action.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <param name="postUrl">
        /// The post url.
        /// </param>
        /// <returns>
        /// Returns the read page view result.
        /// </returns>
        [HttpGet]
        public ActionResult Read(string url, string postUrl)
        {
            try
            {
                return this.View(this.BlogPostView(url, postUrl));
            }
            catch (ResourceException)
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="url">
        /// The blog url.
        /// </param>
        /// <param name="postUrl">
        /// The post url.
        /// </param>
        /// <returns>
        /// Returns the blog post page view model.
        /// </returns>
        private BlogPostPageViewModel BlogPostView(string url, string postUrl)
        {
            var blog = this.blogTasks.GetBlog(url);

            if (blog == null)
            {
                throw new ResourceException();
            }

            var post = new BlogPost();

            if (!string.IsNullOrEmpty(postUrl))
            {
                post = blog.BlogPosts.FirstOrDefault(x => x.Url.Equals(postUrl, StringComparison.InvariantCultureIgnoreCase));
            }

            var cachedTags = this.cachingProvider.Get<Domain.Tags.Tag>();

            return this.blogPostPageViewModelMapper.MapFrom(blog, post, cachedTags);
        }
    }
}