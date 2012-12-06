namespace Leatn.Infrastructure.NHibernateMaps.Overrides
{
    using Domain.Blog.BlogPost;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

    /// <summary>
    /// The news article overrrides.
    /// </summary>
    public class BlogPostOverrides :  IAutoMappingOverride<BlogPost>
    {
        /// <summary>
        /// The override.
        /// </summary>
        /// <param name="mapping">
        /// The mapping.
        /// </param>
        public void Override(AutoMapping<BlogPost> mapping)
        {
            mapping.References(a => a.Blog).ForeignKey("BlogId").Not.Nullable();
            mapping.HasMany(x => x.Comments).Not.LazyLoad();
            mapping.HasManyToMany(x => x.Tags).Cascade.None().Not.LazyLoad().Table("BlogPostTag");
        }
    }
}