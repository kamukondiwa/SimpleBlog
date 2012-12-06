namespace Leatn.Framework.Compareres
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The int year date time comparer.
    /// </summary>
    public class IntYearDateTimeComparer : IComparer<int>
    {
        /// <summary>
        /// The compare.
        /// </summary>
        /// <param name="year1">
        /// The year 1.
        /// </param>
        /// <param name="year2">
        /// The year 2.
        /// </param>
        /// <returns>
        /// The comparison result.
        /// </returns>
        public int Compare(int year1, int year2)
        {
            var dateOne = new DateTime(year1, 1, 1);
            var dateTwo = new DateTime(year2, 1, 1);

            return DateTime.Compare(dateOne, dateTwo);
        }
    }
}