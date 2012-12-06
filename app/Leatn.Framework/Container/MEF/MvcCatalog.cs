namespace Leatn.Framework.Container.MEF
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.ComponentModel.Composition.ReflectionModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The mvc catalog.
    /// </summary>
    public class MvcCatalog : ComposablePartCatalog, ICompositionElement
    {
        /// <summary>
        /// The locker.
        /// </summary>
        private readonly object locker = new object();

        /// <summary>
        /// The types.
        /// </summary>
        private readonly Type[] types;

        /// <summary>
        /// The parts.
        /// </summary>
        private IQueryable<ComposablePartDefinition> parts;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcCatalog"/> class.
        /// </summary>
        /// <param name="types">
        /// The types.
        /// </param>
        public MvcCatalog(params Type[] types)
        {
            this.types = types;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcCatalog"/> class.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        public MvcCatalog(Assembly assembly)
        {
            try
            {
                this.types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                this.types = typeLoadException.Types;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcCatalog"/> class.
        /// </summary>
        /// <param name="dir">
        /// The dir.
        /// </param>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        public MvcCatalog(string dir, string pattern)
        {
            var fileSet = new List<Type>();

            foreach (var fileName in Directory.GetFiles(dir, pattern))
            {
                var assembly = Assembly.LoadFrom(fileName);
                fileSet.AddRange(assembly.GetExportedTypes());
            }

            this.types = fileSet.ToArray();
        }

        /// <summary>
        /// Gets Parts.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                return this.InternalParts;
            }
        }

        /// <summary>
        /// Gets ICompositionElement.DisplayName.
        /// </summary>
        string ICompositionElement.DisplayName
        {
            get
            {
                return "MvcCatalog";
            }
        }

        /// <summary>
        /// Gets InternalParts.
        /// </summary>
        private IQueryable<ComposablePartDefinition> InternalParts
        {
            get
            {
                if (this.parts == null)
                {
                    lock (this.locker)
                    {
                        if (this.parts == null)
                        {
                            var partsCollection = new List<ComposablePartDefinition>();

                            foreach (var type in this.types)
                            {
                                var typeCatalog = new TypeCatalog(type);
                                var part = typeCatalog.Parts.FirstOrDefault();

                                if (part == null)
                                {
                                    continue;
                                }

                                if (typeof(IController).IsAssignableFrom(type))
                                {
                                    part = new ControllerPartDefinitionDecorator(part, type, type.Name, type.Namespace);
                                }

                                partsCollection.Add(part);
                            }

                            Thread.MemoryBarrier();

                            this.parts = partsCollection.AsQueryable();
                        }
                    }
                }

                return this.parts;
            }
        }

        /// <summary>
        /// Gets ICompositionElement.Origin.
        /// </summary>
        ICompositionElement ICompositionElement.Origin
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// The controller part definition decorator.
        /// </summary>
        private class ControllerPartDefinitionDecorator : ComposablePartDefinition
        {
            /// <summary>
            /// The controller name.
            /// </summary>
            private readonly string controllerName;

            /// <summary>
            /// The controller namespace.
            /// </summary>
            private readonly string controllerNamespace;

            /// <summary>
            /// The controller type.
            /// </summary>
            private readonly Type controllerType;

            /// <summary>
            /// The inner.
            /// </summary>
            private readonly ComposablePartDefinition inner;

            /// <summary>
            /// The locker.
            /// </summary>
            private readonly object locker = new object();

            /// <summary>
            /// The redefined exports.
            /// </summary>
            private IEnumerable<ExportDefinition> redefinedExports;

            /// <summary>
            /// Initializes a new instance of the <see cref="ControllerPartDefinitionDecorator"/> class.
            /// </summary>
            /// <param name="inner">
            /// The inner.
            /// </param>
            /// <param name="controllerType">
            /// The controller type.
            /// </param>
            /// <param name="controllerName">
            /// The controller name.
            /// </param>
            /// <param name="controllerNamespace">
            /// The controller namespace.
            /// </param>
            public ControllerPartDefinitionDecorator(
                ComposablePartDefinition inner, Type controllerType, string controllerName, string controllerNamespace)
            {
                this.inner = inner;
                this.controllerType = controllerType;
                this.controllerName = controllerName;
                this.controllerNamespace = controllerNamespace;
            }

            /// <summary>
            /// Gets ExportDefinitions.
            /// </summary>
            public override IEnumerable<ExportDefinition> ExportDefinitions
            {
                get
                {
                    if (this.redefinedExports == null)
                    {
                        lock (this.locker)
                        {
                            if (this.redefinedExports == null)
                            {
                                var exports = this.inner.ExportDefinitions;
                                var metadata = new Dictionary<string, object>();
                                metadata[MefConstants.ControllerNameMetadataName] = this.controllerName.Substring(
                                    0, this.controllerName.Length - "Controller".Length);
                                metadata[MefConstants.ControllerNamespaceMetadataName] = this.controllerNamespace;
                                metadata[MefConstants.ExportedTypeIdentityMetadataName] =
                                    MefConstants.ControllerTypeIdentity;

                                var controllerExport =
                                    ReflectionModelServices.CreateExportDefinition(
                                        new LazyMemberInfo(this.controllerType), 
                                        MefConstants.ControllerContract, 
                                        new Lazy<IDictionary<string, object>>(() => metadata), 
                                        this.inner as ICompositionElement);

                                Thread.MemoryBarrier();

                                this.redefinedExports = exports.Union(new[] { controllerExport }).ToArray();
                            }
                        }
                    }

                    return this.redefinedExports;
                }
            }

            /// <summary>
            /// Gets ImportDefinitions.
            /// </summary>
            public override IEnumerable<ImportDefinition> ImportDefinitions
            {
                get
                {
                    return this.inner.ImportDefinitions;
                }
            }

            /// <summary>
            /// The create part.
            /// </summary>
            /// <returns>
            /// </returns>
            public override ComposablePart CreatePart()
            {
                return this.inner.CreatePart();
            }
        }
    }
}