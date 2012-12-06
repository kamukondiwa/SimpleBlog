namespace Leatn.Domain.Contracts
{
    using SharpArch.Core.DomainModel;

    public interface IReferenceData : IEntityWithTypedId<int>
    {
        string Name { get; set; }
    }
}