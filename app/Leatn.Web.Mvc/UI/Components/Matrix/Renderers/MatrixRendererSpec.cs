namespace Leatn.Web.Mvc.UI.Components.Matrix.Renderers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;

    using Components.Contracts;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Utility;

    using Models;

    using Renderers.Contracts;

    using Rhino.Mocks;

    public abstract class context_for_matrix_renderer : Specification<MatrixRenderer<TestModel>>
    {
        protected static IRowRenderer<TestModel> row_renderer;

        protected static IComponentOutput component_output;

        Establish context = () =>
            {
                row_renderer = DependencyOf<IRowRenderer<TestModel>>();
                component_output = new ComponentOutput(new ViewContext(), new StringWriter());
                row_renderer.Stub(x => x.Output).Return(component_output);
            };

    }

    public class when_matrix_renderer_is_asked_to_render_start_tag : context_for_matrix_renderer
    {
        Because of = () => subject.RenderStartTag();

        It should_render_an_html_table_opening_tag = () => subject.Output.Writer.ToString().ShouldEqual("\r\n<table>");
    }

    public class when_matrix_renderer_is_asked_to_render_end_tag : context_for_matrix_renderer
    {
        Because of = () => subject.RenderEndTag();

        It should_render_an_html_table_closing_tag = () => subject.Output.Writer.ToString().ShouldEqual("\r\n</table>");
    }

    public class when_matrix_renderer_is_asked_to_render_matrix : context_for_matrix_renderer
    {
        static MatrixModel<TestModel> the_matrix_model;

        Establish context = () =>
        {
            the_matrix_model = new MatrixModel<TestModel> { Rows = new List<Row<TestModel>> { new Row<TestModel>() } };
        };

        Because of = () => subject.RenderMatrix(the_matrix_model);

        It should_ask_the_row_renderer_to_render_the_rows_on_the_matrix_model = () => the_matrix_model.Rows.Each(x => row_renderer.AssertWasCalled(r => r.RenderRow(x)));
    }
}