namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Utility;

    using Models;

    using Rhino.Mocks;

    public abstract class context_for_row_mapper : Specification<RowMapper<TestModel>>
    {
        protected static ICellMapper<TestModel> cell_mapper;

        Establish context = () =>
            {
                cell_mapper = DependencyOf<ICellMapper<TestModel>>();
            };
    }

    public class when_the_row_mapper_is_asked_to_map_from_cell_data : context_for_row_mapper
    {

        static Row<TestModel> the_mapped_row;

        static IEnumerable<TestModel> the_cell_data;

        Establish context = () =>
            {
                the_cell_data = new List<TestModel>
                    {
                        new TestModel{ Name = "TestItem1"},
                        new TestModel{ Name = "TestItem2"},
                        new TestModel{ Name = "TestItem3"}
                    };
            };

        Because of = () =>
            {
                the_mapped_row = subject.MapFrom(the_cell_data);
            };

        It should_ask_the_cell_mapper_to_map_all_the_row_data = () => the_cell_data.Each(x => cell_mapper.AssertWasCalled(m => m.MapFrom(x)));

        It should_return_a_model_with_the_right_number_of_cells = () => the_mapped_row.Cells.Count().ShouldEqual(the_cell_data.Count());
    }
}