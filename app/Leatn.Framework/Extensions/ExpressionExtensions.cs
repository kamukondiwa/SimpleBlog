namespace Leatn.Framework.Extensions
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    /// The expression extensions.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <typeparam name="TDestination">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public static TDestination Evaluate<TSource, TDestination>(
            this Expression<Func<TSource, TDestination>> action, TSource source)
        {
            var expression = action.Compile();
            var expressionResult = expression.Invoke(source);
            return expressionResult;
        }
    }
}