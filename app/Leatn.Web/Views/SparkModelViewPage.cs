namespace Leatn.Web.Views
{
    #region Using Directives

    using System.Collections.Generic;

    using MvcContrib.FluentHtml;
    using MvcContrib.FluentHtml.Behaviors;

    using Spark.Web.Mvc;

    #endregion

    /// <summary>
    /// The spark model view page.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class SparkModelViewPage<T> : SparkView<T>, IViewModelContainer<T>
        where T : class
    {
        /// <summary>
        /// The behaviors.
        /// </summary>
        private readonly List<IBehaviorMarker> behaviors = new List<IBehaviorMarker>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkModelViewPage{T}"/> class.
        /// </summary>
        protected SparkModelViewPage()
        {
            this.behaviors.Add(new ValidationBehavior(() => this.ViewData.ModelState));
        }

        /// <summary>
        /// Gets Behaviors.
        /// </summary>
        public IEnumerable<IBehaviorMarker> Behaviors
        {
            get
            {
                return this.behaviors;
            }
        }

        /// <summary>
        /// Gets or sets HtmlNamePrefix.
        /// </summary>
        public string HtmlNamePrefix { get; set; }

        /// <summary>
        /// Gets ViewModel.
        /// </summary>
        public T ViewModel
        {
            get
            {
                return this.Model;
            }
        }
    }
}