namespace Leatn.Web.Controllers.Comments.Mappers
{
    #region Using Directives

    using AutoMapper;

    using Leatn.Domain.Blog.BlogPostComment;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Comments.Mappers.Contracts;
    using Leatn.Web.Controllers.Comments.ViewModels;

    #endregion

    /// <summary>
    /// The blog post comment page view model mapper.
    /// </summary>
    public class BlogPostCommentPageViewModelMapper : BaseMapper<BlogPostComment, BlogPostCommentPageViewModel>, 
                                                      IBlogPostCommentPageViewModelMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="tag">
        /// The blog post comment instance to map from.
        /// </param>
        /// <returns>
        /// The mapped blog post comment page view model.
        /// </returns>
        public override BlogPostCommentPageViewModel MapFrom(BlogPostComment tag)
        {
            var blogPostCommentPageViewModel = base.MapFrom(tag);
            blogPostCommentPageViewModel.CommentDate = tag.CommentDate.ToString("dd MMMM yyyy");
            return blogPostCommentPageViewModel;
        }

        /// <summary>
        /// The create map.
        /// </summary>
        protected override void CreateMap()
        {
            Mapper.CreateMap<BlogPostComment, BlogPostCommentPageViewModel>().ForMember(
                x => x.CommentDate, a => a.Ignore());
        }
    }
}