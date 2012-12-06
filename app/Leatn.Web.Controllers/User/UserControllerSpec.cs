namespace Leatn.Web.Controllers.User
{
    using System.Web.Mvc;

    using Blog;

    using Domain.Contracts.Tasks;
    using Domain.User;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Mvc;

    using Mappers.Contracts;

    using Rhino.Mocks;

    using ViewModels;

    public abstract class context_for_user_controller : Specification<UserController>
    {
        protected static IUserSaveDetailsMapper the_user_save_details_mapper;

        protected static IUserTasks the_user_tasks;

        protected static IUserSignOnDetailsMapper the_user_sign_on_details_mapper;

        Establish context = () =>
            {
                the_user_save_details_mapper = DependencyOf<IUserSaveDetailsMapper>();
                the_user_tasks = DependencyOf<IUserTasks>();
                the_user_sign_on_details_mapper = DependencyOf<IUserSignOnDetailsMapper>();
            };
    }

    public class when_the_register_action_is_asked_to_load_the_view : context_for_user_controller
    {
        private static ActionResult result;

        Because of = () =>
            {
                result = subject.Register();
            };

        It should_return_a_user_page_view_model_to_the_view = () => result.ShouldBeAView().And().Model<UserPageViewModel>().ShouldNotBeNull();
    }

    public class when_the_register_action_is_asked_to_handle_a_registration_request : context_for_user_controller
    {
        static UserPageViewModel the_page_view_model;

        static ActionResult result;

        static UserSaveDetails the_user_save_details;

        Establish context = () =>
            {
                the_page_view_model = new UserPageViewModel();

                the_user_save_details_mapper.Stub(x => x.MapFrom(the_page_view_model.Form))
            .Return(the_user_save_details);
            };

        Because of = () =>
            {
                result = subject.Register(the_page_view_model);
            };

        It should_ask_the_user_save_details_mapper_to_map_from_the_form_view_model = () => the_user_save_details_mapper.AssertWasCalled(x => x.MapFrom(the_page_view_model.Form));

        It should_ask_the_user_tasks_the_save_the_the_user_details = () => the_user_tasks.AssertWasCalled(x => x.Save(the_user_save_details));

        It should_ask_the_user_tasks_to_sign_the_user_in = () => the_user_tasks.AssertWasCalled(x => x.SignOn(the_user_save_details));

        It should_redirect_the_user_to_the_home_page = () => result.ShouldBeARedirectToRoute().And().ShouldRedirectToAction<BlogController>(c => c.Index());

    }

    public class when_the_sign_on_is_asked_to_load_the_view : context_for_user_controller
    {
        static ActionResult result;

        static string the_return_url;

        Because of = () =>
        {
            result = subject.SignOn(the_return_url);
        };

        It should_return_a_user_sign_on_page_view_model_to_the_view = () => result.ShouldBeAView().And().Model<UserSignOnPageViewModel>().ShouldNotBeNull();

    }

    public class when_the_sign_on_is_asked_to_handle_a_user_sign_on_request : context_for_user_controller
    {
        static UserSignOnPageViewModel the_page_view_model;

        static ActionResult result;

        static UserSignOnDetails the_user_sign_on_details;

        Establish context = () =>
        {
            the_page_view_model = new UserSignOnPageViewModel();

            the_user_sign_on_details_mapper.Stub(x => x.MapFrom(the_page_view_model.Form))
        .Return(the_user_sign_on_details);
        };

        Because of = () =>
        {
            result = subject.SignOn(the_page_view_model);
        };

        It should_ask_the_user_sign_on_details_mapper_to_map_from_the_form_view_model = () => the_user_sign_on_details_mapper.AssertWasCalled(x => x.MapFrom(the_page_view_model.Form));

        It should_ask_the_user_tasks_to_sign_on_using_the_sign_on_details = () => the_user_tasks.SignOn(the_user_sign_on_details);

        It should_redirect_the_user_to_the_home_page = () => result.ShouldBeARedirectToRoute().And().ShouldRedirectToAction<BlogController>(c => c.Index());

    }
}