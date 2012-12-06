namespace Leatn.Web.Mvc.UI.Components.Navigation {
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    public class RouteValues : IAttributeAccessor {
        private IDictionary<string, string> attributes;

        public IDictionary<string, string> Attributes {
            get {
                EnsureAttributes();
                return this.attributes;
            }
        }

        private void EnsureAttributes() {
            if (this.attributes == null) {
                this.attributes = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }
        }

        protected virtual string GetAttribute(string key) {
            EnsureAttributes();
            string value;
            this.attributes.TryGetValue(key, out value);
            return value;
        }

        protected virtual void SetAttribute(string key, string value) {
            EnsureAttributes();
            this.attributes[key] = value;
        }

        #region IAttributeAccessor Members
        string IAttributeAccessor.GetAttribute(string key) {
            return GetAttribute(key);
        }

        void IAttributeAccessor.SetAttribute(string key, string value) {
            SetAttribute(key, value);
        }
        #endregion
    }
}
