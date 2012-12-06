namespace Leatn.Infrastructure.NHibernateMaps.Overrides
{
    using Domain.Blog;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

    /// <summary>
    /// The blog overrides.
    /// </summary>
    public class BlogOverrides : IAutoMappingOverride<Blog>
    {
        /// <summary>
        /// The override.
        /// </summary>
        /// <param name="mapping">
        /// The mapping.
        /// </param>
        public void Override(AutoMapping<Blog> mapping)
        {
            mapping.References(a => a.Author).ForeignKey("UserId").Not.Nullable().Not.LazyLoad();
            mapping.HasMany(x => x.BlogPosts).Not.LazyLoad();
        }
    }
}