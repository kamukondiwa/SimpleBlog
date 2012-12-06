namespace Leatn.Web.Mvc.UI.Components.Contracts
{
    #region Using Directives

    using System.IO;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The component output contract.
    /// </summary>
    public interface IComponentOutput
    {
        /// <summary>
        /// Gets Context.
        /// </summary>
        ViewContext Context { get; }

        /// <summary>
        /// Gets Writer.
        /// </summary>
        TextWriter Writer { get; }
    }
}