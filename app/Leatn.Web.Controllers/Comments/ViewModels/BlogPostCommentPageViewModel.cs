namespace Leatn.Web.Controllers.Comments.ViewModels
{
    #region Using Directives

    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The blog post comment page view model.
    /// </summary>
    public class BlogPostCommentPageViewModel : PageViewModel
    {
        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets CommentDate.
        /// </summary>
        public string CommentDate { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public string Username { get; set; }
    }
}