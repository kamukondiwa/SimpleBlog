namespace Leatn.Web.Mvc.UI.Components.Matrix
{
    using System.Collections.Generic;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    using Mappers.Contracts;

    using Models;

    using Renderers.Contracts;

    using Rhino.Mocks;

    public abstract class context_for_matrix_builder : Specification<MatrixBuilder<TestModel>>
    {
        protected static IMatrixRenderer<TestModel> matrix_renderer;

        protected static IMatrixModelMapper<TestModel> matrix_model_mapper;

        Establish context = () =>
            {
                matrix_renderer = DependencyOf<IMatrixRenderer<TestModel>>();
                matrix_model_mapper = DependencyOf<IMatrixModelMapper<TestModel>>();
            };
    }

    public class when_the_matrix_builder_is_asked_to_build : context_for_matrix_builder
    {
        static MatrixSource<TestModel> matrix_source;

        static MatrixModel<TestModel> the_matrix_model;

        Establish context = () =>
            {
                var source = new List<TestModel> { new TestModel { Name = "New Item" } };
                const int rows = 2;
                const int columns = 3;
                matrix_source = new MatrixSource<TestModel>(source, rows, columns);
                ProvideBasicConstructorArgument(matrix_source);

                the_matrix_model = new MatrixModel<TestModel>();

                matrix_model_mapper.Stub(x => x.MapFrom(matrix_source)).Return(the_matrix_model);
            };

        Because of = () => subject.Build();

        It should_ask_the_matrix_renderer_to_render_start_tag = () => matrix_renderer.AssertWasCalled(x => x.RenderStartTag());
        It should_ask_the_matrix_model_mapper_to_map_from_the_source = () => matrix_model_mapper.AssertWasCalled(x => x.MapFrom(matrix_source));
        It should_ask_the_matrix_renderer_to_render_the_matrix = () => matrix_renderer.AssertWasCalled(x => x.RenderMatrix(the_matrix_model));
        It should_ask_the_matrix_renderer_to_render_end_tag = () => matrix_renderer.AssertWasCalled(x => x.RenderEndTag());
    }
}