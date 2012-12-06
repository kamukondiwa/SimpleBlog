namespace Leatn.Web.Controllers.Blog.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;

    using Leatn.Domain.Blog;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.Blog.ViewModels;

    #endregion

    /// <summary>
    /// The blog user page view model mapper contract.
    /// </summary>
    public interface IBlogUserPageViewModelMapper : IMapper<IEnumerable<Blog>, BlogUserPageViewModel>
    {
    }
}