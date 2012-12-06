using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using Leatn.Domain.User;
using FluentNHibernate.Automapping;

namespace Leatn.Infrastructure.NHibernateMaps.Overrides
{
    public class UserOverrides : IAutoMappingOverride<User>
    {
        /// <summary>
        /// The override.
        /// </summary>
        /// <param name="mapping">
        /// The mapping.
        /// </param>
        public void Override(AutoMapping<User> mapping)
        {
            mapping.HasMany(x => x.Blogs).Not.LazyLoad();
        }
    }
}
