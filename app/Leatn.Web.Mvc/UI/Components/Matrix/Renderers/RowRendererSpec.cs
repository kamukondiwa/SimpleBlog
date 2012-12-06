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

    public abstract class context_for_row_renderer : Specification<RowRenderer<TestModel>>
    {
        protected static ICellRenderer<TestModel> cell_renderer;

        private static IComponentOutput component_output;

        Establish context = () =>
            {
                cell_renderer = DependencyOf<ICellRenderer<TestModel>>();
                component_output = new ComponentOutput(new ViewContext(), new StringWriter());
                cell_renderer.Stub(x => x.Output).Return(component_output);
            };
    }

    public class when_row_renderer_is_asked_to_render_start_tag : context_for_row_renderer
    {
        Because of = () => subject.RenderStartTag();

        It should_render_an_html_table_row_opening_tag = () => subject.Output.Writer.ToString().ShouldEqual("\r\n<tr>");
    }

    public class when_row_renderer_is_asked_to_render_end_tag : context_for_row_renderer
    {
        Because of = () => subject.RenderEndTag();

        It should_render_an_html_table_row_closing_tag = () => subject.Output.Writer.ToString().ShouldEqual("\r\n</tr>");
    }

    public class when_row_renderer_is_asked_to_render_row : context_for_row_renderer
    {
        static Row<TestModel> the_row;

        Establish context = () =>
        {
            the_row = new Row<TestModel> { Cells = new List<Cell<TestModel>> { new Cell<TestModel>(new TestModel()) } };
        };

        Because of = () => subject.RenderRow(the_row);

        It should_ask_the_cell_renderer_to_render_the_cells_on_the_row = () => the_row.Cells.Each(x => cell_renderer.AssertWasCalled(r => r.RenderCell(x)));
    }
}