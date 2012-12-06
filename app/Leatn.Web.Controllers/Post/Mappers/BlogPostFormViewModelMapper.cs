namespace Leatn.Web.Controllers.Post.Mappers
{
    using Contracts;

    using Domain.Blog.BlogPost;

    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The blog post form view model mapper.
    /// </summary>
    public class BlogPostFormViewModelMapper : BaseMapper<BlogPost, BlogPostFormViewModel>, IBlogPostFormViewModelMapper
    {
        protected override void CreateMap()
        {
            AutoMapper.Mapper.CreateMap<BlogPost, BlogPostFormViewModel>().ForMember(x => x.Tags, o => o.Ignore());
        }
    }
}