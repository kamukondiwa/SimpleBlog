namespace Leatn.Framework.Extensions
{
    #region Using Directives

    using Castle.MicroKernel.Registration;

    using System;
    using System.Linq;

    #endregion

    public static class WindsorExtensions
    {
        /// <summary>
        /// Searches for the first interface found associated with the 
        /// <see cref="ServiceDescriptor" /> which is not generic and which 
        /// is found in the specified namespace.
        /// </summary>
        public static BasedOnDescriptor FirstNonGenericCoreInterface(this ServiceDescriptor descriptor, string interfaceNamespace)
        {
            return descriptor.Select(
                delegate(Type type, Type baseType)
                {
                    var interfaces = type.GetInterfaces()
                        .Where(t => t.IsGenericType == false &&
                                    t.Namespace.StartsWith(interfaceNamespace));

                    if (interfaces.Count() > 0)
                    {
                        return new[] { interfaces.ElementAt(0) };
                    }

                    return null;
                });
        }
    }
}