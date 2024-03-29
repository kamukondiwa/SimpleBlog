// -------------------------------------------------------------------------------------------------
// <auto-generated>    
//  Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
// -------------------------------------------------------------------------------------------------
namespace Leatn.Web.Controllers.Blog.Mappers
{
    using System.Collections.Generic;

    using Contracts;

    using Domain.Blog;
    using Domain.User;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Utility;

    using Rhino.Mocks;

    public abstract class context_for_blog_user_page_view_model_mapper : Specification<BlogUserPageViewModelMapper>
    {
        protected static IBlogSummaryViewModelMapper blog_summary_view_model_mapper;

        Establish context = () =>
            {
                blog_summary_view_model_mapper = DependencyOf<IBlogSummaryViewModelMapper>();
            };
    }

    public class when_the_blog_user_page_view_model_mapper_is_asked_to_map_from_some_user_blogs : context_for_blog_user_page_view_model_mapper
    {
        static IEnumerable<Blog> the_user_blogs;

        Establish context = () =>
            {
                the_user_blogs = new List<Blog> { new Blog { Author = new User { Username = "username" } } };
            };

        Because of = () => subject.MapFrom(the_user_blogs);

        It should_ask_the_blog_summary_view_model_mapper_to_map_from_each_of_the_user_blogs = () => the_user_blogs.Each(b => blog_summary_view_model_mapper.AssertWasCalled(x => x.MapFrom(b)));

    }
}