namespace Leatn.Domain.Contracts.Repositories
{
    #region Using Directives

    using System.Linq;

    using Framework.Contracts.Specifications;

    #endregion

    public interface IReferenceDataRepository
    {
        IQueryable<TReferenceData> FindAll<TReferenceData>() where TReferenceData : IReferenceData;

        IQueryable<TReferenceData> FindAll<TReferenceData>(ILinqSpecification<TReferenceData> specification)
            where TReferenceData : IReferenceData;

        TReferenceData FindOne<TReferenceData>(int id) where TReferenceData : IReferenceData;
    }
}