namespace Leatn.Web.Controllers.Shared.ActionResults
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Xml.Linq;

    using Leatn.Web.Controllers.RSS.ViewModels;

    #endregion

    /// <summary>
    /// The rss result.
    /// </summary>
    public class RssResult : ContentResult
    {
        /// <summary>
        /// The feed view model.
        /// </summary>
        private readonly RSSFeedViewModel feedViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RssResult"/> class.
        /// </summary>
        /// <param name="feedViewModel">
        /// The feed view model.
        /// </param>
        public RssResult(RSSFeedViewModel feedViewModel)
        {
            this.feedViewModel = feedViewModel;
        }

        /// <summary>
        /// The execute result.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            var items = this.feedViewModel.Elements;
            var feed = this.RssFeedTransfrom(items);

            this.Content = feed.ToString();
            this.ContentType = "text/xml";
            this.ContentEncoding = Encoding.UTF8;

            base.ExecuteResult(context);
        }

        /// <summary>
        /// The rss feed transfrom.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The XML document representing the rss feed.
        /// </returns>
        private XDocument RssFeedTransfrom(IEnumerable<RssElementViewModel> items)
        {
            XNamespace atom = "http://www.w3.org/2005/Atom";
            var atomLink = new XElement(
                atom + "link", 
                new XAttribute("href", this.feedViewModel.Channel.Link), 
                new XAttribute("rel", "self"), 
                new XAttribute("type", "application/rss+xml"));

            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"), 
                new XElement(
                    "rss", 
                    new XAttribute("version", "2.0"), 
                    new XAttribute(XNamespace.Xmlns + "atom", "http://www.w3.org/2005/Atom"), 
                    new XElement(
                        "channel", 
                        atomLink, 
                        new XElement("title", this.feedViewModel.Channel.Title), 
                        new XElement("link", this.feedViewModel.Channel.Link), 
                        new XElement("description", this.feedViewModel.Channel.Description), 
                        new XElement("copyright", this.feedViewModel.Channel.Copyright), 
                        items.Select(
                            item =>
                            new XElement(
                                "item", 
                                new XElement("title", item.Title), 
                                new XElement("description", item.Description), 
                                new XElement("guid", item.Link), 
                                new XElement("link", item.Link), 
                                new XElement("pubDate", item.PubDate))))));
        }
    }
}