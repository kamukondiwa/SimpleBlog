namespace Leatn.Web.Mvc.UI.Components
{
    #region Using Directives

    using System.IO;
    using System.Web.Mvc;

    using Leatn.Web.Mvc.UI.Components.Contracts;

    #endregion

    /// <summary>
    /// The compoonent factory.
    /// </summary>
    public static class ComponentFactory
    {
        /// <summary>
        /// The get component output.
        /// </summary>
        /// <param name="viewContext">
        /// The view context.
        /// </param>
        /// <param name="textWriter">
        /// The text writer.
        /// </param>
        /// <returns>
        /// The component output.
        /// </returns>
        public static IComponentOutput GetComponentOutput(ViewContext viewContext, TextWriter textWriter)
        {
            return new ComponentOutput(viewContext, textWriter);
        }
    }
}