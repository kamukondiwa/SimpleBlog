namespace Leatn.Infrastructure.NHibernateMaps.Overrides
{
    #region Using Directives

    using Domain.Tags;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

    #endregion

    public class TagOverrides : IAutoMappingOverride<Tag>
    {
        /// <summary>
        /// The override.
        /// </summary>
        /// <param name="mapping">
        /// The mapping.
        /// </param>
        public void Override(AutoMapping<Tag> mapping)
        {
            mapping.HasMany(t => t.Children).Not.LazyLoad();
        }
    }
}