// -------------------------------------------------------------------------------------------------
// <auto-generated>    
//  Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
// -------------------------------------------------------------------------------------------------
namespace Leatn.Web.Controllers.Shared.Mappers
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    using Domain.Blog;
    using Domain.Blog.BlogPost;

    using Framework.Extensions;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Utility;

    using Rhino.Mocks;

    public abstract class context_for_archive_section_view_model_mapper : Specification<ArchiveSectionViewModelMapper>
    {
        protected static IArchiveYearViewModelMapper archive_year_view_model_mapper;

        Establish context = () =>
            {
                archive_year_view_model_mapper = DependencyOf<IArchiveYearViewModelMapper>();
            };
    }

    public class when_the_archive_section_view_model_mapper_is_asked_to_map_from : context_for_archive_section_view_model_mapper
    {
        static Blog the_blog;

        static DateTime the_creation_date;

        static IList<BlogPost> the_blog_posts;

        Establish context = () =>
            {
                the_creation_date = DateTime.Now.AddYears(-4);

                the_blog_posts = new List<BlogPost>();

                the_blog = new Blog { CreationDate = the_creation_date, BlogPosts = the_blog_posts};
            };

        Because of = () => subject.MapFrom(the_blog);

        It should_ask_the_archive_year_view_model_mapper_to_map_from_the_blog_for_each_year_since_the_blog_was_created = () => the_creation_date.ToPastYears().Each(x => archive_year_view_model_mapper.AssertWasCalled(m => m.MapFrom(the_blog, x)));
    }
}