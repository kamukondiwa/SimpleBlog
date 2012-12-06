namespace Leatn.Infrastructure.NHibernateMaps.Conventions
{
    #region Using Directives

    using System;
    using System.Reflection;
    using FluentNHibernate.Conventions;

    using SharpArch.Core.DomainModel;

    #endregion

    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(FluentNHibernate.Member property, Type type)
        {
            if (property == null || typeof(Entity) == type.BaseType)
            {
                return type.Name + "Id";
            }

            return property.Name + "Id";
        }
    }
}