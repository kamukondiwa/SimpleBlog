namespace Leatn.Infrastructure.Repositories
{
    #region Using Directives

    using System.Linq;

    using Leatn.Domain.Contracts;
    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Framework.Contracts.Specifications;

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public class ReferenceDataRepository : IReferenceDataRepository
    {
        public IQueryable<TReferenceData> FindAll<TReferenceData>() where TReferenceData : IReferenceData
        {
            return GetLinqRepository<TReferenceData>().FindAll();
        }

        public IQueryable<TReferenceData> FindAll<TReferenceData>(ILinqSpecification<TReferenceData> specification)
            where TReferenceData : IReferenceData
        {
            return GetLinqRepository<TReferenceData>().FindAll(specification);
        }

        public TReferenceData FindOne<TReferenceData>(int id) where TReferenceData : IReferenceData
        {
            return GetLinqRepository<TReferenceData>().FindOne(id);
        }

        private static ILinqRepository<TReferenceData> GetLinqRepository<TReferenceData>()
            where TReferenceData : IReferenceData
        {
            return ServiceLocator.Current.GetInstance<ILinqRepository<TReferenceData>>();
        }
    }
}