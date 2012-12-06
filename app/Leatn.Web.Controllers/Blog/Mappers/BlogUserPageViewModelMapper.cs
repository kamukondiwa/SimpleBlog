namespace Leatn.Web.Controllers.Blog.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Framework.Enumerable;

    using Leatn.Domain.Blog;
    using Leatn.Framework.Compareres;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.Mappers.Contracts;
    using Leatn.Web.Controllers.Blog.ViewModels;

    #endregion

    /// <summary>
    /// The blog user page view model mapper.
    /// </summary>
    public class BlogUserPageViewModelMapper : IBlogUserPageViewModelMapper
    {
        /// <summary>
        /// The blog summary view model mapper.
        /// </summary>
        private readonly IBlogSummaryViewModelMapper blogSummaryViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogUserPageViewModelMapper"/> class.
        /// </summary>
        /// <param name="blogSummaryViewModelMapper">
        /// The blog summary view model mapper.
        /// </param>
        public BlogUserPageViewModelMapper(IBlogSummaryViewModelMapper blogSummaryViewModelMapper)
        {
            this.blogSummaryViewModelMapper = blogSummaryViewModelMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="userBlogs">
        /// The userBlogs.
        /// </param>
        /// <returns>
        /// The mapped blog user page view model.
        /// </returns>
        public BlogUserPageViewModel MapFrom(IEnumerable<Blog> userBlogs)
        {
            var model = new BlogUserPageViewModel
                {
                    Blogs = userBlogs
                        .ToList()
                        .MapAllUsing(this.blogSummaryViewModelMapper)
                        .OrderByDescending(x => x.CreationDate, new StringDateComparer())
                };

            if (!userBlogs.IsNullOrEmpty())
            {
                model.Author = userBlogs.First().Author.Username;
            }

            return model;
        }
    }
}