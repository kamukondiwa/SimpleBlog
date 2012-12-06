namespace Leatn.Web.Mvc.Extensions
{
    #region Using Directives

    using System.Web.Mvc;

    using xVal.ServerSide;

    #endregion

    /// <summary>
    /// The rules exception extensions.
    /// </summary>
    public static class RulesExceptionExtensions
    {
        /// <summary>
        /// The add model state errors.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="modelState">
        /// The model state.
        /// </param>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public static void AddModelStateErrors(
            this RulesException exception, ModelStateDictionary modelState, object obj)
        {
            exception.AddModelStateErrors(modelState, obj.GetType().Name);
        }

        /// <summary>
        /// The add model state errors.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="modelState">
        /// The model state.
        /// </param>
        public static void AddModelStateErrors(this RulesException exception, ModelStateDictionary modelState)
        {
            exception.AddModelStateErrors(modelState, string.Empty);
        }
    }
}