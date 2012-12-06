namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    #region Using Directives

    using AutoMapper;

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.ViewModels;

    #endregion

    /// <summary>
    /// The blog summary view model mapper.
    /// </summary>
    public class BlogSummaryViewModelMapper : BaseMapper<Blog, BlogSummaryViewModel>, IBlogSummaryViewModelMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blog">
        /// The blog input.
        /// </param>
        /// <returns>
        /// The mapped blog summary view model.
        /// </returns>
        public override BlogSummaryViewModel MapFrom(Blog blog)
        {
            var model = base.MapFrom(blog);
            
            model.CreationDate = blog.CreationDate.ToString("dd MMMM yyyy");
            model.Author = blog.Author.Username;
            
            return model;
        }

        /// <summary>
        /// The create map.
        /// </summary>
        protected override void CreateMap()
        {
            Mapper.CreateMap<Blog, BlogSummaryViewModel>()
                .ForMember(x => x.CreationDate, o => o.Ignore())
                .ForMember(x => x.Author, o => o.Ignore());
        }
    }
}