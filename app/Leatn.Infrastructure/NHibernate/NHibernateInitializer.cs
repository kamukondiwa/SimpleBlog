namespace Leatn.Infrastructure.NHibernate
{
    using System;

    /// <summary>
    /// Initialises the NHibernate session.
    /// </summary>
    public class NHibernateInitializer
    {
        /// <summary>
        /// The lock to ensure only one instance of the initializer is created.
        /// </summary>
        private static readonly object syncLock = new object();
        
        /// <summary>
        /// The singleton instance of the nhibernate initializer.
        /// </summary>
        private static NHibernateInitializer instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateInitializer"/> class.
        /// </summary>
        protected NHibernateInitializer()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether [N hibernate session is loaded].
        /// </summary>
        /// <value>
        /// <c>True</c> If [N hibernate session is loaded]; otherwise, <c>false</c>.
        /// </value>
        public bool NHibernateSessionIsLoaded
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>A singleton instance of this object.</returns>
        public static NHibernateInitializer Instance()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new NHibernateInitializer { NHibernateSessionIsLoaded = false };
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Initializes the specified init method.
        /// </summary>
        /// <param name="initMethod">The init method.</param>
        public void Initialize(Action initMethod)
        {
            if (!this.NHibernateSessionIsLoaded)
            {
                lock (syncLock)
                {
                    if (!this.NHibernateSessionIsLoaded)
                    {
                        initMethod();
                        this.NHibernateSessionIsLoaded = true;
                    }
                }
            }
        }
    }
}