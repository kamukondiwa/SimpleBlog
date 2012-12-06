namespace Leatn.Web.Mvc.Caching.Contracts
{
    using System;

    public interface ICachingProvider
    {
        T Get<T>() where T : class;

        T Get<T>(string key) where T : class;

        T TryGet<T>(string cacheKey, Func<T> cacheRenewalFunction) where T : class;

        void Insert<T>(T instance) where T : class;

        void Insert<T>(T instance, string key) where T : class;

        void Remove(string key);

        void AddDependencyTo(string key);

        void ResetDependenciesOn(string key);
    }
}