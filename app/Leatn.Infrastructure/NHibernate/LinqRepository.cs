using NHibernate.Linq;

namespace Leatn.Infrastructure.NHibernate
{
    #region Using Directives

    using System.Linq;

    using System.Collections.Generic;

    using Domain.Specifications;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Contracts.Repositories;

    using SharpArch.Data.NHibernate;

    #endregion

    /// <summary>
    /// The linq repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class LinqRepository<T> : Repository<T>, ILinqRepository<T>
    {
        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        public override void Delete(T target)
        {
            this.Session.Delete(target);
        }

        /// <summary>
        /// The find all.
        /// </summary>
        /// <returns>
        /// </returns>
        public IQueryable<T> FindAll()
        {
            return this.Session.Linq<T>().AsQueryable();
        }

        /// <summary>
        /// The find all.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// </returns>
        public IQueryable<T> FindAll(ILinqSpecification<T> specification)
        {
            return specification.SatisfyingElementsFrom(this.Session.Linq<T>());
        }

        /// <summary>
        /// The find all.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// </returns>
        public IQueryable<T> FindAll(ILinqSpecification<T, T> specification)
        {
            return specification.SatisfyingElementsFrom(this.Session.Linq<T>());
        }

        /// <summary>
        /// The find one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        public T FindOne(int id)
        {
            return this.Session.Get<T>(id);
        }

        /// <summary>
        /// The find one.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// </returns>
        public T FindOne(ILinqSpecification<T> specification)
        {
            return specification.SatisfyingElementsFrom(this.Session.Linq<T>()).SingleOrDefault();
        }

        /// <summary>
        /// The find one.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// </returns>
        public T FindOne(ILinqSpecification<T, T> specification)
        {
            return specification.SatisfyingElementsFrom(this.Session.Linq<T>()).SingleOrDefault();
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Save(T entity)
        {
            try
            {
                this.Session.Save(entity);
            }
            catch
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }

                throw;
            }

            this.Session.Flush();
        }

        /// <summary>
        /// The save and evict.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void SaveAndEvict(T entity)
        {
            this.Save(entity);
            this.Session.Evict(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(T entity)
        {
            try
            {
                this.Session.Update(entity);
            }
            catch
            {
                if (this.Session.IsOpen)
                {
                    this.Session.Close();
                }

                throw;
            }

            this.Session.Flush();
        }

        /// <summary>
        /// The update and evict.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void UpdateAndEvict(T entity)
        {
            this.Update(entity);
            this.Session.Evict(entity);
        }
    }
}