namespace Leatn.Domain.Specifications.Testing
{
    #region Using Directives

    using Framework.Contracts.Specifications;

    using Leatn.Domain.Contracts.Services;
    using Leatn.Domain.Specifications.Contracts;

    using Rhino.Mocks;

    using SharpArch.Core.DomainModel;

    #endregion

    /// <summary>
    /// The testing extensions.
    /// </summary>
    public static class TestingExtensions
    {
        /// <summary>
        /// The mock and.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <typeparam name="T">
        /// The entity type.
        /// </typeparam>
        /// <returns>
        /// The mocked linq specification builder.
        /// </returns>
        public static ILinqSpecificationBuilder<T> MockAnd<T>(
            this ILinqSpecificationBuilder<T> builder, ILinqSpecification<T> specification) where T : Entity
        {
            builder.Stub(x => x.And(specification)).Return(builder);
            return builder;
        }

        /// <summary>
        /// The mock or.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <typeparam name="T">
        /// The entity type.
        /// </typeparam>
        /// <returns>
        /// The mocked linq specification builder.
        /// </returns>
        public static ILinqSpecificationBuilder<T> MockOr<T>(
            this ILinqSpecificationBuilder<T> builder, ILinqSpecification<T> specification) where T : Entity
        {
            builder.Stub(x => x.Or(specification)).Return(builder);
            return builder;
        }

        /// <summary>
        /// The mock using.
        /// </summary>
        /// <typeparam name="T">
        /// The entity type.
        /// </typeparam>
        /// <param name="builderService">
        /// The builder service.
        /// </param>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <returns>
        /// The mocked linq specification builder.
        /// </returns>
        public static ILinqSpecificationBuilder<T> MockUsing<T>(
            this ILinqSpecificationBuilderService builderService, ILinqSpecification<T> specification) where T : Entity
        {
            var linqSpecificationBuilder = MockRepository.GenerateStub<ILinqSpecificationBuilder<T>>();
            builderService.Stub(x => x.Using(specification)).Return(linqSpecificationBuilder);
            return linqSpecificationBuilder;
        }

        /// <summary>
        /// The ToSpecification method stub.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="specification">
        /// The specification.
        /// </param>
        /// <typeparam name="T">
        /// The return value of a ToSpecification() method call.
        /// </typeparam>
        public static void StubToSpecificationReturn<T>(
            this ILinqSpecificationBuilder<T> builder, ILinqSpecification<T> specification) where T : Entity
        {
            builder.Stub(x => x.ToSpecification()).Return(specification);
        }
    }
}