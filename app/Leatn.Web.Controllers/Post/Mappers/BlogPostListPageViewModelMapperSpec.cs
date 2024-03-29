// -------------------------------------------------------------------------------------------------
// <auto-generated>    
//  Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
// -------------------------------------------------------------------------------------------------
namespace Leatn.Web.Controllers.Post.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Blog.ViewModels;

    using Contracts;

    using Domain.Blog;
    using Domain.Blog.BlogPost;
    using Domain.Contracts.Services;
    using Domain.User;

    using Framework.Traversal;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    using Rhino.Mocks;

    using ViewModels;

    public abstract class context_for_blog_list_page_view_model_mapper : Specification<BlogPostListPageViewModelMapper>
    {
        protected static IBlogPostSummaryPageViewModelMapper blogPostSummaryPageViewModelMapper;

        protected static IIdentityService identity_service;

        Establish context = () =>
            {
                blogPostSummaryPageViewModelMapper = DependencyOf<IBlogPostSummaryPageViewModelMapper>();
                identity_service = DependencyOf<IIdentityService>();
            };
    }

    public class when_the_mapper_is_asked_to_map_from_a_list_of_blogs : context_for_blog_list_page_view_model_mapper
    {
        static BlogPostListPageViewModel the_model;

        static ICollection<Domain.Blog.BlogPost.BlogPost> the_blogs;
        
        static BlogPost the_blog_post;

        static Blog the_current_users_blog;

        static string the_blog_url;

        static User the_user;

        Establish context = () =>
            {
                the_blog_post = new Domain.Blog.BlogPost.BlogPost { PostDate = DateTime.Now };

                the_blogs = new List<Domain.Blog.BlogPost.BlogPost> { the_blog_post};

                blogPostSummaryPageViewModelMapper.Stub(x => x.MapFrom(the_blog_post)).Return(new BlogPostSummaryPageViewModel{PostDate = "11-11-11"});

                the_blog_url = "awesome-blog";

                the_current_users_blog = new Blog { Url = the_blog_url };

                the_user = new User { Blogs = new Collection<Blog> { the_current_users_blog } };

                identity_service.Stub(x => x.GetCurrentUser()).Return(the_user);
            };

        Because of = () =>
            {
                the_model = subject.MapFrom(the_blogs);
            };

        It should_map_the_results_correctly = () => the_blogs.ForEach(blog => blogPostSummaryPageViewModelMapper.AssertWasCalled(x => x.MapFrom(blog)));

        It should_set_the_show_add_post_link_flag = () => the_model.ShowAddPostLink.ShouldBeTrue();

        It should_ask_the_identity_service_for_the_current_user = () => identity_service.AssertWasCalled(t => t.GetCurrentUser());

        It should_map_the_current_users_blog_url_to_the_model = () => the_model.BlogUrl.ShouldBeTheSameAs(the_blog_url);

    }
}