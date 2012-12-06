namespace Leatn.Framework.Extensions
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class TestExtensions
    {
        /// <summary>
        /// Sets non public properties of objects.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="o">The o.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        public static void SetNonPublicProperty<TTarget, TProperty>(
            this TTarget o, Expression<Func<TTarget, TProperty>> property, TProperty value)
        {
            var theProperty = (property.Body as MemberExpression).Member as PropertyInfo;
            theProperty.SetValue(o, value, null);
        }
    }
}