namespace Leatn.Web.Controllers.Post.Mappers.Contracts
{
    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The blog summary page view model mapper contract.
    /// </summary>
    public interface IBlogPostSummaryPageViewModelMapper : IMapper<Domain.Blog.BlogPost.BlogPost, BlogPostSummaryPageViewModel>
    {
    }
}