using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using Leatn.Domain.Shared;
using SharpArch.Core.DomainModel;

namespace Leatn.Infrastructure.NHibernateMaps
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.GetInterfaces().Any(x =>
                 x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }

        public override bool ShouldMap(Member member)
        {
            return base.ShouldMap(member) && member.CanWrite;
        }

        public override bool AbstractClassIsLayerSupertype(System.Type type)
        {
            return type == typeof(EntityWithTypedId<>) || type == typeof(Entity) || type == typeof(AddressableContentBase);
        }

        public override bool IsId(Member member)
        {
            return member.Name == "Id";
        }
    }
}
