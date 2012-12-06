namespace Leatn.Web.Mvc.UI.Components.Matrix.Mappers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Utility;

    using Models;

    using Rhino.Mocks;

    public abstract class context_for_matrix_model_mapper : Specification<MatrixModelMapper<TestModel>>
    {
        protected static IRowMapper<TestModel> row_mapper;

        Establish context = () =>
            {
                row_mapper = DependencyOf<IRowMapper<TestModel>>();
            };
    }

    public class when_the_the_matrix_model_mapper_is_asked_to_map_from_a_matrix_source : context_for_matrix_model_mapper
    {
        static MatrixSource<TestModel> the_matrix_source;

        static MatrixModel<TestModel> the_mapped_model;

        static IEnumerable<TestModel> the_source;

        static int the_rows;

        static int the_columns;

        Establish context = () =>
            {
                the_source = new List<TestModel>
                    {
                        new TestModel{ Name = "TestItem1"},
                        new TestModel{ Name = "TestItem2"},
                        new TestModel{ Name = "TestItem3"},
                        new TestModel{ Name = "TestItem4"},
                        new TestModel{ Name = "TestItem5"},
                        new TestModel{ Name = "TestItem6"},
                        new TestModel{ Name = "TestItem7"}
                    };

                the_rows = 3;
                the_columns = 3;

                the_matrix_source = new MatrixSource<TestModel>(the_source, the_rows, the_columns);
            };

        Because of = () =>
            {
                the_mapped_model = subject.MapFrom(the_matrix_source);
            };

        It should_ask_the_row_mapper_to_map_all_row_data = () => the_matrix_source.RowData.Each(x => row_mapper.AssertWasCalled(m => m.MapFrom(x)));
    }
}