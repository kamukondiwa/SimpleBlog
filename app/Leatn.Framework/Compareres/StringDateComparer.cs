namespace Leatn.Framework.Compareres
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The string date comparer.
    /// </summary>
    public class StringDateComparer : IComparer<string>
    {
        /// <summary>
        /// The compare.
        /// </summary>
        /// <param name="input1">
        /// The input 1.
        /// </param>
        /// <param name="input2">
        /// The input 2.
        /// </param>
        /// <returns>
        /// The comparison result.
        /// </returns>
        public int Compare(string input1, string input2)
        {
            var dateOne = DateTime.Parse(input1);
            var dateTwo = DateTime.Parse(input2);

            return DateTime.Compare(dateOne, dateTwo);
        }
    }
}