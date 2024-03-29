// -------------------------------------------------------------------------------------------------
// <auto-generated>    
//  Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
// -------------------------------------------------------------------------------------------------
namespace Leatn.Tasks.Search
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Domain.Contracts.Repositories;
    using Domain.Contracts.Services;
    using Domain.Contracts.Specifications;
    using Domain.Shared;
    using Domain.Specifications.Contracts;
    using Domain.Specifications.Testing;

    using Factories.Contracts;
    using Domain.Blog;
    using Domain.Blog.BlogPost;

    using Framework.Contracts.Specifications;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    using Rhino.Mocks;

    public abstract class context_for_search_tasks : Specification<SearchTasks>
    {
        protected static IBlogRepository blog_repository;

        protected static IBlogSpecificationFactory blog_specification_factory;

        protected static IBlogPostSpecificationFactory blog_post_specification_factory;

        protected static IBlogPostRepository blog_post_repository;

        protected static ILinqSpecificationBuilderService blog_linq_specification_builder_service;

        Establish context = () =>
            {
                blog_repository = DependencyOf<IBlogRepository>();
                blog_specification_factory = DependencyOf<IBlogSpecificationFactory>();
                blog_post_specification_factory = DependencyOf<IBlogPostSpecificationFactory>();
                blog_post_repository = DependencyOf<IBlogPostRepository>();
                blog_linq_specification_builder_service = DependencyOf<ILinqSpecificationBuilderService>();
            };
    }

    public class when_the_search_tasks_is_asked_to_search_for_a_blogs : context_for_search_tasks
    {
        static IQueryable<AddressableContentBase> result;

        static string the_keywords;

        static SearchParameters the_search_parameters;

        static ILinqSpecification<Blog> the_blog_search_specification;

        static IQueryable<Blog> the_blogs_matching_the_blog_specification;

        static DateTime the_date_from;

        static ILinqSpecification<Blog> the_date_from_specification;

        static DateTime the_date_to;

        static ILinqSpecification<Blog> the_date_to_specification;

        static ILinqSpecification<Blog> the_blog_keyword_specification;

        static ILinqSpecificationBuilder<Blog> the_linq_specification_builder;

        Establish context = () =>
        {
            the_keywords = "search criteria";

            the_date_from = DateTime.Now;

            the_date_from_specification = new AdHocSpecification<Blog>(x => true);

            blog_specification_factory.Stub(x => x.GetDateFromSpecification(the_date_from)).Return(
                the_date_from_specification);

            the_date_to = DateTime.Now;

            the_date_to_specification = new AdHocSpecification<Blog>(x => true);

            blog_specification_factory.Stub(x => x.GetDateToSpecification(the_date_to)).Return(
                the_date_to_specification);

            the_blog_keyword_specification = new AdHocSpecification<Blog>(x => true);

            blog_specification_factory.Stub(x => x.GetKeywordSpecification(the_keywords)).Return(
                the_blog_keyword_specification);

            the_blog_search_specification = new AdHocSpecification<Blog>(x => true);

            blog_linq_specification_builder_service
                   .MockUsing(the_blog_keyword_specification)
                   .MockAnd(the_date_from_specification)
                   .MockAnd(the_date_to_specification)
                   .StubToSpecificationReturn(the_blog_search_specification);

            the_search_parameters = new SearchParameters { Keywords = the_keywords, ContentType = SearchContentType.Blog, DateFrom = the_date_from, DateTo = the_date_to };

            the_blogs_matching_the_blog_specification = new List<Blog> { new Blog { CreationDate = DateTime.Now } }.AsQueryable();

            blog_repository.Stub(x => x.FindAll(the_blog_search_specification)).Return(
                the_blogs_matching_the_blog_specification);
        };

        Because of = () =>
        {
            result = subject.Search(the_search_parameters);
        };

        It should_ask_the_blog_specification_factory_for_the_keyword_specification_matching_the_search_parameter = () => blog_specification_factory.AssertWasCalled(x => x.GetKeywordSpecification(the_search_parameters.Keywords));

        It should_ask_the_blog_specification_factory_for_the_date_from_specification_matching_the_search_parameter = () => blog_specification_factory.AssertWasCalled(x => x.GetDateFromSpecification(the_date_from));

        It should_ask_the_blog_specification_factory_for_the_date_to_specification_macthing_the_search_parameter = () => blog_specification_factory.AssertWasCalled(x => x.GetDateToSpecification(the_date_to));

        It should_ask_the_blog_repository_for_the_blogs_matching_the_blog_specification = () => blog_repository.AssertWasCalled(x => x.FindAll(the_blog_search_specification));

        It should_ask_the_blog_linq_specification_builder_service_to_use_the_keyword_specification_date_from_specification_and_date_to_specification = () => blog_linq_specification_builder_service
                .AssertWasCalled(x => x
                .Using(the_blog_keyword_specification)
                .And(the_date_from_specification)
                .And(the_date_to_specification)
                .ToSpecification());

        It should_return_the_blogs_matching_the_keyword_specification = () => result.ShouldContain(the_blogs_matching_the_blog_specification.First());
    }

    public class when_the_search_tasks_is_asked_to_search_for_blog_posts : context_for_search_tasks
    {
        static SearchParameters the_search_parameters;

        static IQueryable<AddressableContentBase> search_results;

        static string the_keywords;

        static ILinqSpecification<BlogPost> the_keyword_specification;

        static IQueryable<BlogPost> the_blog_post_search_result;

        static ILinqSpecification<BlogPost> the_date_from_specification;

        static ILinqSpecification<BlogPost> the_date_to_specification;

        static ILinqSpecification<BlogPost> the_search_specification;

        static DateTime the_date_from;

        static DateTime the_date_to;

        Establish context = () =>
        {
            the_keywords = "search criteria";

            the_date_from = DateTime.Now;

            the_date_to = DateTime.Now;

            the_search_parameters = new SearchParameters { Keywords = the_keywords, ContentType = SearchContentType.Post, DateFrom = the_date_from, DateTo = the_date_to };

            the_keyword_specification = new AdHocSpecification<BlogPost>(x => true);

            blog_post_specification_factory.Stub(x => x.GetKeywordSpecification(the_keywords)).Return(the_keyword_specification);

            the_date_from_specification = new AdHocSpecification<BlogPost>(x => true);

            blog_post_specification_factory.Stub(x => x.GetDateFromSpecification(the_date_from)).Return(the_date_from_specification);

            the_date_to_specification = new AdHocSpecification<BlogPost>(x => true);

            blog_post_specification_factory.Stub(x => x.GetDateToSpecification(the_date_to)).Return(the_date_to_specification);

            the_search_specification = new AdHocSpecification<BlogPost>(x => true);

            blog_linq_specification_builder_service
                  .MockUsing(the_keyword_specification)
                  .MockAnd(the_date_from_specification)
                  .MockAnd(the_date_to_specification)
                  .StubToSpecificationReturn(the_search_specification);

            the_blog_post_search_result = new List<BlogPost> { new BlogPost { PostDate = DateTime.Now } }.AsQueryable();

            blog_post_repository.Stub(x => x.FindAll(the_search_specification)).Return(the_blog_post_search_result);

        };

        Because of = () =>
        {
            search_results = subject.Search(the_search_parameters);
        };

        It should_ask_the_blog_post_specification_for_the_keyword_specification_matching_the_search_parameter = () => blog_post_specification_factory.AssertWasCalled(x => x.GetKeywordSpecification(the_keywords));

        It should_ask_the_blog_post_specification_factory_for_the_date_from_specification_matching_the_search_parameter = () => blog_post_specification_factory.AssertWasCalled(x => x.GetDateFromSpecification(the_date_from));

        It should_ask_the_blog_post_specification_factory_for_the_date_to_specification_macthing_the_search_parameter = () => blog_post_specification_factory.AssertWasCalled(x => x.GetDateToSpecification(the_date_to));

        It should_ask_the_blog_linq_specification_builder_service_to_use_the_keyword_specification_date_from_specification_and_date_to_specification = () => blog_linq_specification_builder_service
            .AssertWasCalled(x => x
            .Using(the_keyword_specification)
            .And(the_date_from_specification)
            .And(the_date_to_specification)
            .ToSpecification());

        It should_ask_the_blog_post_repository_for_the_blog_posts_matching_the_search_specification = () => blog_post_repository.AssertWasCalled(x => x.FindAll(the_search_specification));

        It should_return_the_blog_posts_matching_the_search_specification = () => search_results.ShouldContain(the_blog_post_search_result.First());
    }
}