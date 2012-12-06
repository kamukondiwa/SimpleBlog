namespace Leatn.Web.Controllers.Post
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Blog;

    using Comments.Mappers.Contracts;
    using Comments.ViewModels;

    using Domain.Blog;
    using Domain.Blog.BlogPostComment;
    using Domain.Contracts.Services;
    using Domain.Tags;
    using Domain.User;

    using Mvc.Caching.Contracts;

    using Post.Mappers.Contracts;
    using Post.ViewModels;
    using Blog.Mappers.Contracts;

    using Domain.Blog.BlogPost;
    using Domain.Contracts.Tasks;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Mvc;

    using Rhino.Mocks;

    public abstract class context_for_post_controller : Specification<PostController>
    {
        protected static IBlogTasks blog_tasks;

        protected static IBlogPageViewModelMapper blog_page_view_model_mapper;

        protected static IBlogPostSaveDetailsMapper blog_post_save_details_mapper;

        protected static IBlogPostPageViewModelMapper blogPostPageViewModelMapper;

        protected static IIdentityService identity_service;

        protected static IBlogPostCommentSaveDetailsMapper the_blog_post_comment_save_details_mapper;

        protected static ICachingProvider the_caching_provider;

        private Establish context = () =>
        {
            blog_tasks = DependencyOf<IBlogTasks>();
            blog_page_view_model_mapper = DependencyOf<IBlogPageViewModelMapper>();
            blog_post_save_details_mapper = DependencyOf<IBlogPostSaveDetailsMapper>();
            blogPostPageViewModelMapper = DependencyOf<IBlogPostPageViewModelMapper>();
            identity_service = DependencyOf<IIdentityService>();
            the_blog_post_comment_save_details_mapper = DependencyOf<IBlogPostCommentSaveDetailsMapper>();
            the_caching_provider = DependencyOf<ICachingProvider>();
        };

    }

    public class when_the_post_add_action_is_called_with_blog_url : context_for_post_controller
    {
        static string the_blog_url;

        static ActionResult result;

        static Domain.Blog.Blog the_blog;

        static BlogPostPageViewModel the_model;

        Establish context = () =>
        {
            the_blog_url = "blog-one";

            the_blog = new Domain.Blog.Blog();

            blog_tasks.Stub(x => x.GetBlog(the_blog_url)).Return(the_blog);

            the_model = new BlogPostPageViewModel();

            blogPostPageViewModelMapper.Stub(x => x.MapFrom(the_blog, null, null)).Return(the_model).IgnoreArguments();
        };

        Because of = () => result = subject.Add(the_blog_url);

        It should_ask_the_blog_tasks_for_the_blog = () => blog_tasks.AssertWasCalled(x => x.GetBlog(the_blog_url));

        It should_ask_the_blog_post_page_view_model_mapper_to_map_the_model = () => blogPostPageViewModelMapper.AssertWasCalled(x => x.MapFrom(the_blog, null, null), a => a.IgnoreArguments());

        It should_return_the_model_to_the_edit_view = () => result.ShouldBeAView().And().Model<BlogPostPageViewModel>().ShouldBeTheSameAs(the_model);
    }

    public class when_the_post_edit_action_is_called_with_blog_url_and_a_post_url : context_for_post_controller
    {
        static string the_blog_url;

        static string the_post_url;

        static ActionResult result;

        static Domain.Blog.Blog the_blog;

        static Domain.Blog.BlogPost.BlogPost the_blog_post;

        static BlogPostPageViewModel the_model;

        static User the_author;

        static Tag cachedTags;


        Establish context = () =>
        {
            the_blog_url = "blog-one";
            the_post_url = "post-one";

            the_blog_post = new Domain.Blog.BlogPost.BlogPost { Url = the_post_url };

            the_author = new User();

            the_blog = new Domain.Blog.Blog
            {
                BlogPosts = new List<Domain.Blog.BlogPost.BlogPost>
                                {
                                    the_blog_post 
                                },
                Author = the_author
            };

            blog_tasks.Stub(x => x.GetBlog(the_blog_url)).Return(the_blog);

            cachedTags = new Tag();

            the_caching_provider.Stub(x => x.Get<Tag>()).Return(cachedTags);

            the_model = new BlogPostPageViewModel();

            blogPostPageViewModelMapper.Stub(x => x.MapFrom(the_blog, the_blog_post, cachedTags)).Return(the_model);

            identity_service.Stub(x => x.GetCurrentUser()).Return(the_author);
        };

        Because of = () => result = subject.Edit(the_blog_url, the_post_url);

        It should_ask_the_blog_tasks_for_the_blog = () => blog_tasks.AssertWasCalled(x => x.GetBlog(the_blog_url));

        It should_ask_the_identity_service_for_the_current_user = () => identity_service.AssertWasCalled(x => x.GetCurrentUser());

        It should_ask_the_blog_post_page_view_model_mapper_to_map_the_model = () => blogPostPageViewModelMapper.AssertWasCalled(x => x.MapFrom(the_blog, the_blog_post, cachedTags));

        It should_return_the_model_to_the_view = () => result.ShouldBeAView().And().Model<BlogPostPageViewModel>().ShouldBeTheSameAs(the_model);

    }

    public class when_the_post_edit_action_is_called_to_save_a_new_blog_post : context_for_post_controller
    {
        static string the_url;

        static BlogPostFormViewModel the_blog_post_form_view_model;

        static BlogPostSaveDetails the_blog_post_save_details;

        static string the_post_url;

        static Blog the_blog;

        static ActionResult result;

        Establish context = () =>
        {
            the_url = "new-blog";

            the_blog_post_form_view_model = new BlogPostFormViewModel { BlogUrl = the_url };

            the_blog = new Blog();
            blog_tasks.Stub(x => x.GetBlog(the_url)).Return(the_blog);

            the_post_url = "new-post";

            the_blog_post_save_details = new BlogPostSaveDetails { Url = the_post_url };

            blog_post_save_details_mapper.Stub(x => x.MapFrom(the_blog_post_form_view_model))
                .Return(the_blog_post_save_details);
        };

        Because of = () =>
        {
            result = subject.Edit(the_blog_post_form_view_model);
        };

        It should_ask_the_blog_tasks_for_the_by_url = () => blog_tasks.AssertWasCalled(x => x.GetBlog(the_url));

        It should_ask_the_blog_post_save_details_mapper_to_map_the_blog_form_view_model = () => blog_post_save_details_mapper.AssertWasCalled(x => x.MapFrom(the_blog_post_form_view_model));

        It should_ask_the_the_blog_tasks_to_save_the_blog_and_blog_post = () => blog_tasks.AssertWasCalled(x => x.Save(the_blog, the_blog_post_save_details));

        It should_return_the_blog_post_read_page_for_the_new_blog_post = () => result.ShouldBeARedirectToRoute().And().ShouldRedirectToAction<PostController>(x => x.Read(the_url, the_blog_post_save_details.Url));
    }

    public class when_the_post_read_action_is_called_with_a_blog_url_and_a_post_url : context_for_post_controller
    {
        static string the_blog_url;

        static string the_post_url;

        static ActionResult result;

        static Domain.Blog.Blog the_blog;

        static Domain.Blog.BlogPost.BlogPost the_blog_post;

        static BlogPostPageViewModel the_model;

        static Tag the_cached_tags;

        Establish context = () =>
        {
            the_blog_url = "blog-one";
            the_post_url = "post-one";

            the_blog_post = new Domain.Blog.BlogPost.BlogPost { Url = the_post_url };

            the_blog = new Domain.Blog.Blog
            {
                BlogPosts = new List<Domain.Blog.BlogPost.BlogPost>
                                {
                                    the_blog_post 
                                }
            };

            blog_tasks.Stub(x => x.GetBlog(the_blog_url)).Return(the_blog);

            the_cached_tags = new Tag();

            the_caching_provider.Stub(x => x.Get<Tag>()).Return(the_cached_tags);

            the_model = new BlogPostPageViewModel();

            blogPostPageViewModelMapper.Stub(x => x.MapFrom(the_blog, the_blog_post, the_cached_tags)).Return(the_model);
        };

        Because of = () => result = subject.Read(the_blog_url, the_post_url);

        It should_ask_the_blog_tasks_for_the_blog = () => blog_tasks.GetBlog(the_blog_url);

        It should_ask_the_blog_post_page_view_model_mapper_to_map_the_model = () => blogPostPageViewModelMapper.AssertWasCalled(x => x.MapFrom(the_blog, the_blog_post, the_cached_tags));

        It should_return_the_model_to_the_view = () => result.ShouldBeAView().And().Model<BlogPostPageViewModel>().ShouldBeTheSameAs(the_model);

    }

    public class when_the_comment_action_is_asked_to_handle_a_post : context_for_post_controller
    {
        static BlogPostCommentFormViewModel the_blog_post_comment_form_view_model;

        static string the_post_url;

        static ActionResult result;

        static string the_blog_url;

        static Blog the_blog;

        static BlogPostCommentSaveDetails the_blog_post_comment_save_details;

        Establish context = () =>
            {
                the_blog_url = "new-blog";

                the_blog = new Blog { Url = the_blog_url };

                blog_tasks.Stub(x => x.GetBlog(the_blog_url)).Return(the_blog);

                the_blog_post_comment_save_details = new BlogPostCommentSaveDetails();

                the_post_url = "blog-post";

                the_blog_post_comment_form_view_model = new BlogPostCommentFormViewModel { BlogUrl = the_blog_url, PostUrl = the_post_url };

                the_blog_post_comment_save_details_mapper.Stub(x => x.MapFrom(the_blog_post_comment_form_view_model)).
                    Return(the_blog_post_comment_save_details);
            };

        Because of = () =>
            {
                result = subject.Comment(the_blog_post_comment_form_view_model);
            };

        It should_ask_the_blog_tasks_to_get_the_blog = () => blog_tasks.AssertWasCalled(x => x.GetBlog(the_blog_url));

        It should_ask_the_comment_save_details_mapper_to_map_the_comment_save_details = () => the_blog_post_comment_save_details_mapper.AssertWasCalled(x => x.MapFrom(the_blog_post_comment_form_view_model));

        It should_ask_the_blog_tasks_to_save_the_blog = () => blog_tasks.AssertWasCalled(x => x.Save(the_blog, the_blog_post_comment_save_details));

        It should_redirect_to_the_blog_read_page = () => result.ShouldRedirectToAction<PostController>(c => c.Read(the_blog_post_comment_form_view_model.BlogUrl, the_blog_post_comment_form_view_model.PostUrl));
    }
}