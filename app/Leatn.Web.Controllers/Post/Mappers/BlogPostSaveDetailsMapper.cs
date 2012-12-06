namespace Leatn.Web.Controllers.Post.Mappers
{
    #region Using Directives

    using System;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Post.Mappers.Contracts;
    using Leatn.Web.Controllers.Post.ViewModels;

    #endregion

    /// <summary>
    /// The blog post save details mapper.
    /// </summary>
    public class BlogPostSaveDetailsMapper : BaseMapper<BlogPostFormViewModel, BlogPostSaveDetails>, 
                                             IBlogPostSaveDetailsMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPostFormViewModel">
        /// The blogPostFormViewModel.
        /// </param>
        /// <returns>
        /// The mapped blog post save details.
        /// </returns>
        public override BlogPostSaveDetails MapFrom(BlogPostFormViewModel blogPostFormViewModel)
        {
            var blogPostSaveDetails = base.MapFrom(blogPostFormViewModel);
            blogPostSaveDetails.PostDate = blogPostSaveDetails.PostDate == DateTime.MinValue ? DateTime.Now : blogPostSaveDetails.PostDate;
            return blogPostSaveDetails;
        }
    }
}