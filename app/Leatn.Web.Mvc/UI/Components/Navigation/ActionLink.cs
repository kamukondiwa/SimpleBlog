namespace Leatn.Web.Mvc.UI.Components.Navigation
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Web.Routing;
    using System.Web.UI;

    #endregion

    [ParseChildren(true)]
    [PersistChildren(false)]
    public class ActionLink : MvcControl
    {
        private string actionName;

        private string controllerName;

        private string routeName;

        private string text;

        private RouteValues values;

        [DefaultValue("")]
        public string ActionName
        {
            get
            {
                return this.actionName ?? String.Empty;
            }
            set
            {
                this.actionName = value;
            }
        }

        [DefaultValue("")]
        public string ControllerName
        {
            get
            {
                return this.controllerName ?? String.Empty;
            }
            set
            {
                this.controllerName = value;
            }
        }

        [DefaultValue("")]
        public string RouteName
        {
            get
            {
                return this.routeName ?? String.Empty;
            }
            set
            {
                this.routeName = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text ?? String.Empty;
            }
            set
            {
                this.text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public RouteValues Values
        {
            get
            {
                if (this.values == null)
                {
                    this.values = new RouteValues();
                }
                return this.values;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var routeValues = new RouteValueDictionary();
            foreach (var attribute in this.Values.Attributes)
            {
                routeValues.Add(attribute.Key, attribute.Value);
            }

            if (!String.IsNullOrEmpty(this.ActionName) && !routeValues.ContainsKey("action"))
            {
                routeValues.Add("action", this.ActionName);
            }
            if (!String.IsNullOrEmpty(this.ControllerName) && !routeValues.ContainsKey("controller"))
            {
                routeValues.Add("controller", this.ControllerName);
            }

            string href = null;
            if (this.DesignMode)
            {
                href = "/";
            }
            else
            {
                var vpd = RouteTable.Routes.GetVirtualPath(this.ViewContext.RequestContext, this.RouteName, routeValues);
                if (vpd == null)
                {
                    throw new InvalidOperationException(
                        "A route that matches the requested values could not be located in the route table.");
                }
                href = vpd.VirtualPath;
            }

            foreach (var attribute in this.Attributes)
            {
                writer.AddAttribute(attribute.Key, attribute.Value);
            }

            if (!this.Attributes.ContainsKey("href"))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Href, href);
            }

            writer.RenderBeginTag(HtmlTextWriterTag.A);

            writer.WriteEncodedText(this.Text);

            writer.RenderEndTag();
        }
    }
}