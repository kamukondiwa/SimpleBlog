namespace Leatn.Tasks.BlogPost.Mappers
{
    using System;

    using AutoMapper;

    using Contracts;

    using Domain.Blog.BlogPost;
    using Domain.Contracts.Repositories;
    using Domain.Tags;

    using Framework.Mapper;

    /// <summary>
    /// The blog post mapper.
    /// </summary>
    public class BlogPostMapper : BaseEntityMapper<BlogPostSaveDetails, BlogPost>, IBlogPostMapper
    {
        private readonly IReferenceDataRepository referenceDataRepository;

        public BlogPostMapper(IReferenceDataRepository referenceDataRepository)
        {
            this.referenceDataRepository = referenceDataRepository;
        }

        public override BlogPost MapFrom(BlogPostSaveDetails blogPostSaveDetails)
        {
            return this.MapFrom(blogPostSaveDetails, new BlogPost());
        }

        public override BlogPost MapFrom(BlogPostSaveDetails blogPostSaveDetails, BlogPost existingEntity)
        {
            var blogPost = base.MapFrom(blogPostSaveDetails, existingEntity);
            blogPost.Tags.Clear();

            foreach (var tag in blogPostSaveDetails.Tags)
            {
                var newTag = this.referenceDataRepository.FindOne<Tag>(Int32.Parse(tag.Substring(tag.LastIndexOf('-') + 1)));
                blogPost.Tags.Add(newTag);
            }

            return blogPost;
        }

        protected override void CreateMap()
        {
            Mapper.CreateMap<BlogPostSaveDetails, BlogPost>()
                .ForMember(x => x.Tags, o => o.Ignore());
        }
    }
}