namespace Leatn.Infrastructure.Services
{
    #region Using Directives

    using System;

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Contracts.Services;
    using Leatn.Domain.Specifications.Contracts;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The linq specification builder service.
    /// </summary>
    public class LinqSpecificationBuilderService : ILinqSpecificationBuilderService
    {
        /// <summary>
        /// The using.
        /// </summary>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <typeparam name="T">
        /// The entity type.
        /// </typeparam>
        /// <returns>
        /// An ILinqSpecificationBuilder.
        /// </returns>
        public ILinqSpecificationBuilder<T> Using<T>(ILinqSpecification<T> specification) where T : Entity
        {
            return new LinqSpecificationBuilder<T>().Using(specification);
        }
    }
}