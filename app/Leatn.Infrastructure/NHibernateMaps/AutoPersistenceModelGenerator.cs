#region Using Directives

using System;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using Leatn.Domain.Blog;
using Leatn.Infrastructure.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

#endregion

namespace Leatn.Infrastructure.NHibernateMaps
{
    #region Using Directives

    

    #endregion

    /// <summary>
    /// Generates the automapping for the domain assembly
    /// </summary>
    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            var mappings = AutoMap.AssemblyOf<Blog>(new AutomappingConfiguration());
            mappings.Conventions.Setup(GetConventions());
            mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
            return mappings;
        }


        private static Action<IConventionFinder> GetConventions()
        {
            return c =>
                       {
                           c.Add<PrimaryKeyConvention>();
                           c.Add<CustomForeignKeyConvention>();
                           c.Add<HasManyConvention>();
                           c.Add<TableNameConvention>();
                       };
        }
    }
}