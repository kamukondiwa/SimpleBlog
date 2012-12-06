namespace Leatn.Web.Mvc.UI.Components
{
    #region Using Directives

    using System.IO;
    using System.Web.Mvc;

    using Leatn.Web.Mvc.UI.Components.Contracts;

    #endregion

    /// <summary>
    /// The grid output.
    /// </summary>
    public class ComponentOutput : IComponentOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentOutput"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="writer">
        /// The writer.
        /// </param>
        public ComponentOutput(ViewContext context, TextWriter writer)
        {
            this.Context = context;
            this.Writer = writer;
        }

        /// <summary>
        /// Gets Context.
        /// </summary>
        public ViewContext Context { get; private set; }

        /// <summary>
        /// Gets Writer.
        /// </summary>
        public TextWriter Writer { get; private set; }
    }
}