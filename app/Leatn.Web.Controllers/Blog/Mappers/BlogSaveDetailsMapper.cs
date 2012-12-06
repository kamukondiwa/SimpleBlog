namespace Leatn.Web.Controllers.Blog.Mappers
{
    #region Using Directives

    using System;

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.Mappers.Contracts;
    using Leatn.Web.Controllers.Blog.ViewModels;

    #endregion

    /// <summary>
    /// The blog save details mapper.
    /// </summary>
    public class BlogSaveDetailsMapper : BaseMapper<BlogFormViewModel, BlogSaveDetails>, IBlogSaveDetailsMappper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogFormViewModel">
        /// The blog form view model.
        /// </param>
        /// <returns>
        /// The mapped blog save details.
        /// </returns>
        public override BlogSaveDetails MapFrom(BlogFormViewModel blogFormViewModel)
        {
            var blogSaveDetails = base.MapFrom(blogFormViewModel);
            blogSaveDetails.CreationDate = blogSaveDetails.CreationDate == DateTime.MinValue ? DateTime.Now : blogSaveDetails.CreationDate;
            return blogSaveDetails;
        }
    }
}