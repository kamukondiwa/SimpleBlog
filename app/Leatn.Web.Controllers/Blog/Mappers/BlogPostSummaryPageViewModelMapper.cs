namespace Leatn.Web.Controllers.Blog.Mappers
{
    #region Using Directives

    using AutoMapper;

    using Leatn.Domain.Blog.BlogPost;
    using Leatn.Framework.Extensions;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Post.Mappers.Contracts;
    using Leatn.Web.Controllers.Post.ViewModels;

    #endregion

    /// <summary>
    /// The blog post summary page view model mapper.
    /// </summary>
    public class BlogPostSummaryPageViewModelMapper : BaseMapper<BlogPost, BlogPostSummaryPageViewModel>, 
                                                      IBlogPostSummaryPageViewModelMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blogPost">
        /// The input.
        /// </param>
        /// <returns>
        /// The mapped blog summary page view model.
        /// </returns>
        public override BlogPostSummaryPageViewModel MapFrom(BlogPost blogPost)
        {
            var blogSummaryPageViewModel = base.MapFrom(blogPost);
            blogSummaryPageViewModel.BlogUrl = blogPost.Blog.Url;
            blogSummaryPageViewModel.Author = blogPost.Blog.Author.Username;
            blogSummaryPageViewModel.PostDate = blogPost.PostDate.ToString("dd MMMM yyyy");
            blogSummaryPageViewModel.Teaser += "{0}...".FormatWith(blogPost.Description);

            return blogSummaryPageViewModel;
        }

        /// <summary>
        /// The create map.
        /// </summary>
        protected override void CreateMap()
        {
            Mapper.CreateMap<BlogPost, BlogPostSummaryPageViewModel>().ForMember(x => x.PostDate, o => o.Ignore()).
                ForMember(x => x.Teaser, o => o.Ignore());
        }
    }
}