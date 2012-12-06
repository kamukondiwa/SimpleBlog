namespace Leatn.Tasks.User
{
    using System;
    using System.Security;

    using Domain.Contracts.Services;
    using Domain.User;

    using Machine.Specifications;

    using Rhino.Mocks;

    using Web.Mvc.Testing;

    public abstract class context_for_user_tasks : TaskSpecification<UserTasks>
    {
        protected static IIdentityService the_identity_service;

        Establish context = () =>
            {
                the_identity_service = DependencyOf<IIdentityService>();
            };
    }

    public class when_the_user_tasks_is_used_to_sign_on_with_valid_and_correct_credentials : context_for_user_tasks
    {
        static UserSignOnDetails the_sign_on_details;

        Establish context = () =>
            {
                the_sign_on_details = new UserSignOnDetails { Username = "username", Password = "password" };
                the_identity_service.Stub(x => x.AuthenticateUser(the_sign_on_details)).Return(true);
            };

        Because of = () => subject.SignOn(the_sign_on_details);

        It should_ask_the_identity_servie_to_authenticate_the_sign_on_detail = () => the_identity_service.AssertWasCalled(x => x.AuthenticateUser(the_sign_on_details));

        It should_ask_the_identity_service_to_sign_on_using_the_sign_on_details = () => the_identity_service.AssertWasCalled(x => x.SignOn(the_sign_on_details));
    }

    public class when_the_user_tasks_is_used_to_sign_on_with_valid_and_incorrect_credentials : context_for_user_tasks
    {
        static UserSignOnDetails the_sign_on_details;

        static Exception exception;

        Establish context = () =>
        {
            the_sign_on_details = new UserSignOnDetails { Username = "username", Password = "password" };
            the_identity_service.Stub(x => x.AuthenticateUser(the_sign_on_details)).Return(false);
        };

        Because of = () => exception = Catch.Exception(() => subject.SignOn(the_sign_on_details));

        It should_ask_the_identity_servie_to_authenticate_the_sign_on_detail = () => the_identity_service.AssertWasCalled(x => x.AuthenticateUser(the_sign_on_details));

        private It should_throw_a_security_exception = () => exception.ShouldBeOfType(typeof(SecurityException));
    }

    public class when_the_user_tasks_is_used_to_sign_on_with_invalid_credentials : context_for_user_tasks
    {
        static UserSignOnDetails the_sign_on_details;

        static Exception result;

        Establish context = () =>
        {
            the_sign_on_details = new UserSignOnDetails();
        };

        Because of = () => result = Catch.Exception(() => subject.SignOn(the_sign_on_details));

        It should_throw_a_rules_exception = () => result.ShouldNotBeNull();
    }
}