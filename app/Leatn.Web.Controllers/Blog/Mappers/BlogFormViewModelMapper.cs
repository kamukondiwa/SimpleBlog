namespace Leatn.Web.Controllers.Blog.Mappers
{
    #region Using Directives

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.Mappers.Contracts;
    using Leatn.Web.Controllers.Blog.ViewModels;

    #endregion

    /// <summary>
    /// The blog form view model mapper.
    /// </summary>
    public class BlogFormViewModelMapper : BaseMapper<Blog, BlogFormViewModel>, IBlogFormViewModelMapper
    {
    }
}