namespace Leatn.Web.Mvc.Caching
{
    #region Using Directives

    using System;
    using System.Web;
    using System.Web.Caching;

    using Contracts;

    #endregion

    public class CachingProvider : ICachingProvider
    {
        private readonly Cache cache;

        public CachingProvider()
        {
            this.cache = HttpContext.Current.Cache;
        }

        public void AddDependencyTo(string key)
        {
            HttpContext.Current.Response.AddCacheItemDependency(key);
        }

        public T Get<T>() where T : class
        {
            return this.cache.Get(typeof(T).FullName) as T;
        }

        public T Get<T>(string key) where T : class
        {
            return this.cache.Get(key) as T;
        }

        public void Insert<T>(T instance) where T : class
        {
            if (instance == null)
                return;

            this.cache.Insert(typeof(T).FullName, instance);
        }

        public void Insert<T>(T instance, string key) where T : class
        {
            if (instance == null)
                return;

            this.cache.Insert(key, instance);
        }

        public void Remove(string key)
        {
            this.cache.Remove(key);
        }

        public void ResetDependenciesOn(string key)
        {
            HttpContext.Current.Cache.Insert(key, DateTime.Now, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
        }

        public T TryGet<T>(string cacheKey, Func<T> cacheRenewalFunction) where T : class
        {
            var cachedValue = this.Get<T>(cacheKey);

            if (cachedValue != null)
            {
                return cachedValue;
            }

            cachedValue = cacheRenewalFunction.Invoke();

            this.Insert(cachedValue, cacheKey);

            return cachedValue;
        }
    }
}