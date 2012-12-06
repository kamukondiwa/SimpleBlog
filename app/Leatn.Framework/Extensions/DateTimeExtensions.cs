namespace Leatn.Framework.Extensions
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    #endregion

    /// <summary>
    /// The date time extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// The to past years.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <returns>
        /// An array containing the year values from the date specified until the current year.
        /// </returns>
        public static IEnumerable<int> ToPastYears(this DateTime dateTime)
        {
            var dates = new List<int>();

            var yearsSinceBlogCreation = DateTime.Now.Year - dateTime.Year;

            var startValue = dateTime.Year;

            for (var i = 0; i <= yearsSinceBlogCreation; i++)
            {
                dates.Add(startValue + i);
            }

            return dates;
        }

        /// <summary>
        /// The to rfc-822 string.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <returns>
        /// The to rfc-822 date string.
        /// </returns>
        public static string ToRFC822String(this DateTime dateTime)
        {
            var builder =
                new StringBuilder(dateTime.ToString("ddd, dd MMM yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture));
            builder.Remove(builder.Length - 3, 1);
            return builder.ToString();
        }
    }
}