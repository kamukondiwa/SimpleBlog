namespace Leatn.Web.Controllers.Shared.Mappers
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Domain.Blog;

    using Framework.Compareres;
    using Framework.Extensions;
    using Framework.Traversal;

    using ViewModels;

    #endregion

    /// <summary>
    /// The archive section view model mapper.
    /// </summary>
    public class ArchiveSectionViewModelMapper : IArchiveSectionViewModelMapper
    {
        /// <summary>
        /// The archive year view model mapper.
        /// </summary>
        private readonly IArchiveYearViewModelMapper archiveYearViewModelMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveSectionViewModelMapper"/> class.
        /// </summary>
        /// <param name="archiveYearViewModelMapper">
        /// The archive year view model mapper.
        /// </param>
        public ArchiveSectionViewModelMapper(IArchiveYearViewModelMapper archiveYearViewModelMapper)
        {
            this.archiveYearViewModelMapper = archiveYearViewModelMapper;
        }

        /// <summary>
        /// The map from.
        /// </summary>
        /// <param name="blog">
        /// The blog input.
        /// </param>
        /// <returns>
        /// The mapped archive section view model.
        /// </returns>
        public ArchiveSectionViewModel MapFrom(Blog blog)
        {
            var archiveSectionViewModel = new ArchiveSectionViewModel();

            var orderedArchives = new List<ArchiveYearViewModel>();

            blog.CreationDate.ToPastYears().ForEach(
                pastYear =>
                    {
                        var archiveYeaViewModel = this.archiveYearViewModelMapper.MapFrom(blog, pastYear);
                        if (archiveYeaViewModel != null)
                        {
                            orderedArchives.Add(archiveYeaViewModel);
                        }
                    });

            archiveSectionViewModel.Archives = orderedArchives.
                OrderByDescending(x => x.ArchiveYear, new IntYearDateTimeComparer());

            return archiveSectionViewModel;
        }
    }
}