namespace Leatn.Web.Controllers.Shared.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Leatn.Domain.Blog;
    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Web.Controllers.Shared.Mappers.Contracts;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The archive year view model mapper.
    /// </summary>
    public class ArchiveYearViewModelMapper : IArchiveYearViewModelMapper
    {
        /// <summary>
        /// The archive months view model mapper.
        /// </summary>
        private readonly IArchiveMonthsViewModelMapper archiveMonthsViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveYearViewModelMapper"/> class.
        /// </summary>
        /// <param name="archiveMonthsViewModelMapper">
        /// The archive months view model mapper.
        /// </param>
        public ArchiveYearViewModelMapper(IArchiveMonthsViewModelMapper archiveMonthsViewModelMapper)
        {
            this.archiveMonthsViewModelMapper = archiveMonthsViewModelMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blog">
        /// The blog to map from.
        /// </param>
        /// <param name="archiveYear">
        /// The the archived post year.
        /// </param>
        /// <returns>
        /// The mappped arcihve year view model.
        /// </returns>
        public ArchiveYearViewModel MapFrom(Blog blog, int archiveYear)
        {
            var blogPosts = blog.BlogPosts.Where(x => x.PostDate.Year == archiveYear);

            var archiveMonthsValues = GetArchiveMonthsValues(blogPosts);

            if (archiveMonthsValues.Count == 0)
            {
                return null;
            }

            var archiveMonths = archiveMonthsValues.Select(x => this.archiveMonthsViewModelMapper.MapFrom(blog, x));

            return new ArchiveYearViewModel
                {
                    BlogUrl = blog.Url, ArchiveYear = archiveYear, ArchiveMonths = archiveMonths 
                };
        }

        /// <summary>
        /// The get archive months values.
        /// </summary>
        /// <param name="blogPosts">
        /// The blog posts.
        /// </param>
        /// <returns>
        /// The unique post date month values the blog posts specifiesd. 
        /// </returns>
        private static List<int> GetArchiveMonthsValues(IEnumerable<BlogPost> blogPosts)
        {
            var archiveMonthsValues = new List<int>();

            foreach (var blogPost in blogPosts)
            {
                if (!archiveMonthsValues.Contains(blogPost.PostDate.Month))
                {
                    archiveMonthsValues.Add(blogPost.PostDate.Month);
                }
            }

            return archiveMonthsValues;
        }
    }
}