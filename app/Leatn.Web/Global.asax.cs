namespace Leatn.Web
{
    #region Using Directives

    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using System.Web;

    using Castle.Windsor;

    using CommonServiceLocator.WindsorAdapter;

    using Framework.Container;
    using Framework.Extensions;

    using Infrastructure.NHibernateMaps;

    using log4net.Config;

    using Microsoft.Practices.ServiceLocation;

    using Mvc.Attributes;
    using Mvc.Caching;
    using Mvc.Caching.Contracts;

    using SharpArch.Data.NHibernate;
    using SharpArch.Web.NHibernate;

    using ComponentRegistrar = CastleWindsor.ComponentRegistrar;
    using NHibernateInitializer = Infrastructure.NHibernate.NHibernateInitializer;

    #endregion

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// The mvc application.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// The web session storage.
        /// </summary>
        private WebSessionStorage webSessionStorage;

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            return WebOutputCacheAttrribute.GetVaryByCustomString(context, "IsAuthenticated");
        }

        /// <summary>
        /// Due to issues on IIS7, the NHibernate initialization must occur in Init().
        /// But Init() may be invoked more than once; accordingly, we introduce a thread-safe
        /// mechanism to ensure it's only initialized once.
        /// See http://msdn.microsoft.com/en-us/magazine/cc188793.aspx for explanation details.
        /// </summary>
        public override void Init()
        {
            base.Init();
            this.webSessionStorage = new WebSessionStorage(this);

            NHibernateInitializer.Instance().Initialize(this.InitialiseNHibernateSessions);
            ReferenceDataLoader.Load();
            var cachingProvider = ServiceLocator.Current.GetInstance<ICachingProvider>();
            cachingProvider.ResetDependenciesOn(CacheDependencies.Web);
        }

        /// <summary>
        /// Initialises a request to the application.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Only initialise the NHibernate Sessions for a non static, i.e. Controller Action request
            NHibernateInitializer.Instance().Initialize(this.InitialiseNHibernateSessions);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        /// <summary>
        /// The application_ error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // Useful for debugging
            var ex = this.Server.GetLastError();
            var reflectionTypeLoadException = ex as ReflectionTypeLoadException;
        }

        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            var container = InitializeServiceLocator();

            ComponentRegistrar.Register(container);
            ComponentInitialiser.Initialise();
        }

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from 
        /// WindsorController to the container.  Also associate the Controller 
        /// with the WindsorContainer ControllerFactory.
        /// </summary>
        /// <returns>
        /// The windsor IOC.
        /// </returns>
        private static IWindsorContainer InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            return container;
        }

        /// <summary>
        /// Initialises the NHibernate session objects.
        /// </summary>
        private void InitialiseNHibernateSessions()
        {
            NHibernateSession.Init(
                this.webSessionStorage,
                new[] { this.Server.MapPath("~/bin/Leatn.Domain.dll") },
                new AutoPersistenceModelGenerator().Generate(),
                this.Server.MapPath("~/Configuration/NHibernate/{0}.config").FormatWith("nhibernate.current_session"));
        }
    }
}