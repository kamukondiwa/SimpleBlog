namespace Leatn.Web
{
    using Domain.Contracts.Repositories;
    using Domain.Tags;

    using Microsoft.Practices.ServiceLocation;

    using Mvc.Caching.Contracts;
    using System.Linq;

    public static class ReferenceDataLoader
    {
        public static void Load()
        {
            var referenceDataRepository = ServiceLocator.Current.GetInstance<IReferenceDataRepository>();
            var cachingProvider = ServiceLocator.Current.GetInstance<ICachingProvider>();

            LoadTagsIntoCache(referenceDataRepository, cachingProvider);
        }

        private static void LoadTagsIntoCache(IReferenceDataRepository referenceDataRepository, ICachingProvider cachingProvider)
        {
            var rootTag = referenceDataRepository.FindAll<Tag>().First(x => x.Parent == null);
            cachingProvider.Insert(rootTag);
        }
    }
}