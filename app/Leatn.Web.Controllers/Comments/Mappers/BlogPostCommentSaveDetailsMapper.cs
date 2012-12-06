namespace Leatn.Web.Controllers.Comments.Mappers
{
    using System;

    using Contracts;

    using Domain.Blog.BlogPostComment;

    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The blog post comment save details mapper.
    /// </summary>
    public class BlogPostCommentSaveDetailsMapper : BaseMapper<BlogPostCommentFormViewModel, BlogPostCommentSaveDetails>, 
                                                    IBlogPostCommentSaveDetailsMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPostCommentFormViewModel">
        /// The blgo post comment form view model.
        /// </param>
        /// <returns>
        /// The mapped blog post comment save details.
        /// </returns>
        public override BlogPostCommentSaveDetails MapFrom(BlogPostCommentFormViewModel blogPostCommentFormViewModel)
        {
            var blogPostCommentSaveDetails = base.MapFrom(blogPostCommentFormViewModel);
            blogPostCommentSaveDetails.CommentDate = blogPostCommentSaveDetails.CommentDate == DateTime.MinValue
                                                         ? DateTime.Now
                                                         : blogPostCommentSaveDetails.CommentDate;
            return blogPostCommentSaveDetails;
        }
    }
}