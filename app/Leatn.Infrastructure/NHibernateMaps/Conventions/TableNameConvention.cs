namespace Leatn.Infrastructure.NHibernateMaps.Conventions
{
    #region Using Directives

    using FluentNHibernate.Conventions;

    using Framework.Extensions;

    #endregion

    public class TableNameConvention : IClassConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            instance.Table("[{0}]".FormatWith(instance.EntityType.Name));
            instance.Schema("dbo");
        }
    }
}