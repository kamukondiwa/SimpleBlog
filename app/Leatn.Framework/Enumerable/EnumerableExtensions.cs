namespace Leatn.Framework.Enumerable
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    /// <summary>
    /// The enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// The fore each.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void ForeEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var local in items)
            {
                action(local);
            }
        }

        /// <summary>
        /// The is null or empty.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <returns>
        /// The is null or empty.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                return true;
            }

            if (collection.Count() == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Convenient replacement for a range 'for' loop. e.g. return an array of int from 10 to 20:
        /// int[] tenToTwenty = 10.to(20).ToArray();
        /// </summary>
        /// <param name="from">
        /// </param>
        /// <param name="to">
        /// </param>
        /// <returns>
        /// </returns>
        public static IEnumerable<int> To(this int from, int to)
        {
            for (var i = from;
                 i <= to;
                 i++)
            {
                yield return i;
            }
        }

        public static IQueryable<T> ToConctreteQueryable<T>(this IQueryable<T> collectionProxy){

            return collectionProxy.ToList().AsQueryable();
        }
    }
}