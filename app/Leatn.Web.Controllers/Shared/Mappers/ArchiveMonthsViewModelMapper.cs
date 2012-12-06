namespace Leatn.Web.Controllers.Shared.Mappers
{
    #region Using Directives

    using System;

    using Leatn.Domain.Blog;
    using Leatn.Web.Controllers.Shared.Mappers.Contracts;
    using Leatn.Web.Controllers.Shared.ViewModels;

    #endregion

    /// <summary>
    /// The archive months view model mapper.
    /// </summary>
    public class ArchiveMonthsViewModelMapper : IArchiveMonthsViewModelMapper
    {
        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blog">
        /// The blog containing the blog posts.
        /// </param>
        /// <param name="archiveMonth">
        /// The archive month.
        /// </param>
        /// <returns>
        /// The collection of months with archived blog posts.
        /// </returns>
        public ArchiveMonthViewModel MapFrom(Blog blog, int archiveMonth)
        {
            return new ArchiveMonthViewModel
                {
                    Value = archiveMonth, Name = new DateTime(1999, archiveMonth, 1).ToString("MMMM") 
                };
        }
    }
}