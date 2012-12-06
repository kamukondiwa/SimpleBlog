namespace Leatn.Web.Mvc.UI.Components.Navigation
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using System.Web.UI;

    #endregion

    // TODO: Consider using custom HTML writer instead of the default one to get prettier rendering

    public abstract class MvcControl : Control, IAttributeAccessor
    {
        private IDictionary<string, string> attributes;

        private ViewContext viewContext;

        private IViewDataContainer viewDataContainer;

        [Browsable(false)]
        public IDictionary<string, string> Attributes
        {
            get
            {
                this.EnsureAttributes();
                return this.attributes;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableViewState
        {
            get
            {
                return base.EnableViewState;
            }
            set
            {
                base.EnableViewState = value;
            }
        }

        public ViewContext ViewContext
        {
            get
            {
                if (this.viewContext == null)
                {
                    // TODO: Is this logic correct? Why not just case Page to ViewPage?
                    var parent = this.Parent;
                    while (parent != null)
                    {
                        var viewPage = parent as ViewPage;
                        if (viewPage != null)
                        {
                            this.viewContext = viewPage.ViewContext;
                            break;
                        }
                        parent = parent.Parent;
                    }
                }
                return this.viewContext;
            }
        }

        public ViewDataDictionary ViewData
        {
            get
            {
                var vdc = this.ViewDataContainer;
                return (vdc == null)
                           ? null
                           : vdc.ViewData;
            }
        }

        public IViewDataContainer ViewDataContainer
        {
            get
            {
                if (this.viewDataContainer == null)
                {
                    var parent = this.Parent;
                    while (parent != null)
                    {
                        this.viewDataContainer = parent as IViewDataContainer;
                        if (this.viewDataContainer != null)
                        {
                            break;
                        }
                        parent = parent.Parent;
                    }
                }
                return this.viewDataContainer;
            }
        }

        protected virtual string GetAttribute(string key)
        {
            this.EnsureAttributes();
            string value;
            this.attributes.TryGetValue(key, out value);
            return value;
        }

        protected virtual void SetAttribute(string key, string value)
        {
            this.EnsureAttributes();
            this.attributes[key] = value;
        }

        private void EnsureAttributes()
        {
            if (this.attributes == null)
            {
                this.attributes = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }
        }

        string IAttributeAccessor.GetAttribute(string key)
        {
            return this.GetAttribute(key);
        }

        void IAttributeAccessor.SetAttribute(string key, string value)
        {
            this.SetAttribute(key, value);
        }
    }
}