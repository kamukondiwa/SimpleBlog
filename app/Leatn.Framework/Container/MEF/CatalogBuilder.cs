namespace Leatn.Framework.Container.MEF
{
    #region Using Directives

    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Reflection;

    #endregion

    /// <summary>
    /// The catalog builder.
    /// </summary>
    public class CatalogBuilder
    {
        /// <summary>
        /// The catalogs.
        /// </summary>
        private readonly IList<ComposablePartCatalog> catalogs = new List<ComposablePartCatalog>();

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// </returns>
        public ComposablePartCatalog Build()
        {
            return new AggregateCatalog(this.catalogs);
        }

        /// <summary>
        /// The for assembly.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <returns>
        /// </returns>
        public CatalogBuilder ForAssembly(Assembly assembly)
        {
            this.catalogs.Add(new AssemblyCatalog(assembly));

            return this;
        }

        /// <summary>
        /// The for mvc assemblies in directory.
        /// </summary>
        /// <param name="directory">
        /// The directory.
        /// </param>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <returns>
        /// </returns>
        public CatalogBuilder ForMvcAssembliesInDirectory(string directory, string pattern)
        {
            this.catalogs.Add(new MvcCatalog(directory, pattern));

            return this;
        }

        /// <summary>
        /// The for mvc assembly.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <returns>
        /// </returns>
        public CatalogBuilder ForMvcAssembly(Assembly assembly)
        {
            this.catalogs.Add(new MvcCatalog(assembly));

            return this;
        }
    }
}