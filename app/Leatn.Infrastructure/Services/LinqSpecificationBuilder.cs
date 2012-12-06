namespace Leatn.Infrastructure.Services
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Contracts.Specifications;
    using Leatn.Domain.Specifications.Contracts;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The linq specification builder service.
    /// </summary>
    /// <typeparam name="T">
    /// The entity type.
    /// </typeparam>
    public class LinqSpecificationBuilder<T> : ILinqSpecificationBuilder<T>
        where T : Entity
    {
        /// <summary>
        /// The specificaiton.
        /// </summary>
        private ILinqSpecification<T> specificaiton;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinqSpecificationBuilder{T}"/> class.
        /// </summary>
        internal LinqSpecificationBuilder()
        {
        }

        /// <summary>
        /// The and operation.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The result of the current linq specification And the specified specification.
        /// </returns>
        public ILinqSpecificationBuilder<T> And(ILinqSpecification<T> specification)
        {
            if (!NullSpecification(specification))
            {
                if (this.specificaiton == null)
                {
                    this.specificaiton = specification;
                }
                else
                {
                    var body = Expression.AndAlso(this.specificaiton.MatchingCriteria.Body, specification.MatchingCriteria.Body);
                    this.SetAsSpecification(body);
                }
            }

            return this;
        }

        /// <summary>
        /// The or operation.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The result of the current linq specification Or the specified specification.
        /// </returns>
        public ILinqSpecificationBuilder<T> Or(ILinqSpecification<T> specification)
        {
            if (!NullSpecification(specification))
            {
                if (this.specificaiton == null)
                {
                    this.specificaiton = specification;
                }
                else
                {
                    var body = Expression.OrElse(this.specificaiton.MatchingCriteria.Body, specification.MatchingCriteria.Body);

                    this.SetAsSpecification(body);
                }
            }

            return this;
        }

        /// <summary>
        /// The to specification.
        /// </summary>
        /// <returns>
        /// The built up specification.
        /// </returns>
        public ILinqSpecification<T> ToSpecification()
        {
            return this.specificaiton;
        }

        /// <summary>
        /// The using.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The linq specification starting point.
        /// </returns>
        public ILinqSpecificationBuilder<T> Using(ILinqSpecification<T> specification)
        {
            if (!NullSpecification(specification))
            {
                this.specificaiton = specification;
            }

            return this;
        }

        /// <summary>
        /// The null specification.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The value indicating if the specification is a  null specification.
        /// </returns>
        private static bool NullSpecification(ILinqSpecification<T> specification)
        {
            Expression<Func<T, bool>> nullSpecification = x => true;

            return specification.MatchingCriteria.Body.Type.Equals(typeof(bool)) && specification.MatchingCriteria.Body.ToString().Equals(nullSpecification.Body.ToString());
        }

        /// <summary>
        /// The set specification.
        /// </summary>
        /// <param name="body">
        /// The expression body.
        /// </param>
        private void SetAsSpecification(Expression body)
        {
            var lambdaExpression = Expression.Lambda<Func<T, bool>>(body, this.specificaiton.MatchingCriteria.Parameters[0]);

            this.specificaiton = new AdHocSpecification<T>(lambdaExpression, string.Empty);
        }
    }
}