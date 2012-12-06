namespace Leatn.Web.Controllers.Post.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Comments.ViewModels;

    using Domain.Tags;

    using Shared.ViewModels;

    #endregion

    /// <summary>
    /// The blog post view model.
    /// </summary>
    public class BlogPostPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostPageViewModel"/> class.
        /// </summary>
        public BlogPostPageViewModel()
        {
            this.Form = new BlogPostFormViewModel();
            this.CommentForm = new BlogPostCommentFormViewModel();
            this.Comments = new List<BlogPostCommentPageViewModel>();
            this.AssignedTags = new List<string>();
        }

        public List<string> AssignedTags { get; set; }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets BlogUrl.
        /// </summary>
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets CommentForm.
        /// </summary>
        public BlogPostCommentFormViewModel CommentForm { get; set; }

        /// <summary>
        /// Gets or sets Comments.
        /// </summary>
        public IList<BlogPostCommentPageViewModel> Comments { get; set; }

        /// <summary>
        /// Gets or sets Form.
        /// </summary>
        public BlogPostFormViewModel Form { get; set; }

        /// <summary>
        /// Gets or sets PostDate.
        /// </summary>
        public string PostDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the show the edit link.
        /// </summary>
        public bool ShowEditLink { get; set; }

        public Tag Tags { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        public string Url { get; set; }
    }
}