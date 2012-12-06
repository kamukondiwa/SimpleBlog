// -------------------------------------------------------------------------------------------------
// <auto-generated>    
//  Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
// -------------------------------------------------------------------------------------------------
namespace Leatn.Web.Controllers.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Contracts;

    using Domain.Shared;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Mvc;

    using Mappers.Contracts;

    using Rhino.Mocks;

    using ViewModels;

    public class context_for_search_controller : Specification<SearchController>
    {
        protected static ISearchParameterMapper search_parameter_mapper;

        protected static ISearchTasks search_tasks;

        protected static ISearchPageViewModelMapper blog_search_page_view_model_mapper;

        Establish context = () =>
            {
                search_parameter_mapper = DependencyOf<ISearchParameterMapper>();
                search_tasks = DependencyOf<ISearchTasks>();
                blog_search_page_view_model_mapper = DependencyOf<ISearchPageViewModelMapper>();
            };

    }

    public class when_the_search_controller_is_asked_to_handle_a_blog_search_request : context_for_search_controller
    {
        static SearchFormViewModel the_blog_search_form_view_model;

        static SearchParameters the_search_parameters;

        static ActionResult result;

        static IQueryable<AddressableContentBase> the_search_results;

        static SearchPageViewModel the_blog_searh_page_view_model;

        Establish context = () =>
            {
                the_blog_search_form_view_model = new SearchFormViewModel();

                the_search_parameters = new SearchParameters();

                search_parameter_mapper.Stub(x => x.MapFrom(the_blog_search_form_view_model)).Return(
                    the_search_parameters);

                the_search_results = new List<AddressableContentBase>().AsQueryable();

                search_tasks.Stub(x => x.Search(the_search_parameters)).Return(the_search_results);

                the_blog_searh_page_view_model = new SearchPageViewModel();

                blog_search_page_view_model_mapper.Stub(x => x.MapFrom(the_search_results, the_search_parameters.ContentType, the_blog_search_form_view_model)).Return(
                    the_blog_searh_page_view_model);
            };

        Because of = () =>
            {
                result = subject.Index(the_blog_search_form_view_model);
            };

        It should_ask_the_search_parameter_mapper_to_map_from_the_search_form_view_model = () => search_parameter_mapper.AssertWasCalled(x => x.MapFrom(the_blog_search_form_view_model));
        It should_ask_the_blog_tasks_to_search_for_the_blogs_by_the_search_parameters = () => search_tasks.AssertWasCalled(x => x.Search(the_search_parameters));
        It should_ask_the_blog_search_page_view_model_mapper_to_map_from_the_result = () => blog_search_page_view_model_mapper.AssertWasCalled(x => x.MapFrom(the_search_results, the_search_parameters.ContentType, the_blog_search_form_view_model));
        It should_return_the_model_to_the_view = () => result.ShouldBeAView().And().Model<SearchPageViewModel>().ShouldBeTheSameAs(the_blog_searh_page_view_model);
    }
}