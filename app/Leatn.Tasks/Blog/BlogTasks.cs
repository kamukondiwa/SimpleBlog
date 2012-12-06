namespace Leatn.Tasks.Blog
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BlogPost.Mappers.Contracts;

    using Comment.Mappers.Contracts;

    using Domain.Blog;
    using Domain.Blog.BlogPost;
    using Domain.Blog.BlogPostComment;
    using Domain.Contracts.Repositories;
    using Domain.Contracts.Services;
    using Domain.Contracts.Tasks;

    using Factories.Contracts;

    using Framework.Validation;

    using Mappers.Contracts;

    using Web.Mvc.Caching;
    using Web.Mvc.Caching.Contracts;

    #endregion

    /// <summary>
    /// The blog tasks.
    /// </summary>
    public class BlogTasks : IBlogTasks
    {
        /// <summary>
        /// The blog mapper.
        /// </summary>
        private readonly IBlogMapper blogMapper;

        /// <summary>
        /// The blog post comment mapper.
        /// </summary>
        private readonly IBlogPostCommentMapper blogPostCommentMapper;

        /// <summary>
        /// The blog post mapper.
        /// </summary>
        private readonly IBlogPostMapper blogPostMapper;

        /// <summary>
        /// The blog repository.
        /// </summary>
        private readonly IBlogRepository blogRepository;

        /// <summary>
        /// The blog specifications factory.
        /// </summary>
        private readonly IBlogSpecificationFactory blogSpecificationFactory;

        /// <summary>
        /// The caching provider.
        /// </summary>
        private readonly ICachingProvider cachingProvider;

        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogTasks"/> class.
        /// </summary>
        /// <param name="blogRepository">
        /// The blog repository.
        /// </param>
        /// <param name="blogSpecificationFactory">
        /// The blog specifications factory.
        /// </param>
        /// <param name="blogMapper">
        /// The blog Mapper.
        /// </param>
        /// <param name="blogPostMapper">
        /// The blog Post Mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        /// <param name="blogPostCommentMapper">
        /// The blog Post Comment Mapper.
        /// </param>
        /// <param name="cachingProvider">
        /// The caching provider.
        /// </param>
        public BlogTasks(
            IBlogRepository blogRepository,
            IBlogSpecificationFactory blogSpecificationFactory,
            IBlogMapper blogMapper,
            IBlogPostMapper blogPostMapper,
            IIdentityService identityService,
            IBlogPostCommentMapper blogPostCommentMapper,
            ICachingProvider cachingProvider)
        {
            this.blogRepository = blogRepository;
            this.blogSpecificationFactory = blogSpecificationFactory;
            this.blogMapper = blogMapper;
            this.blogPostMapper = blogPostMapper;
            this.identityService = identityService;
            this.blogPostCommentMapper = blogPostCommentMapper;
            this.cachingProvider = cachingProvider;
        }

        /// <summary>
        /// The get archive blog posts.
        /// </summary>
        /// <param name="blogUrl">
        /// The blog url.
        /// </param>
        /// <param name="archiveYear">
        /// The archive year.
        /// </param>
        /// <returns>
        /// The blog posts.
        /// </returns>
        public IEnumerable<BlogPost> GetArchivedBlogPosts(string blogUrl, int archiveYear)
        {
            var blog = this.GetBlog(blogUrl);

            if (blog == null)
            {
                return new List<BlogPost>();
            }

            return blog.BlogPosts.Where(x => x.PostDate.Year == archiveYear);
        }

        /// <summary>
        /// The get archive blog posts.
        /// </summary>
        /// <param name="blogUrl">
        /// The blog url.
        /// </param>
        /// <param name="archiveYear">
        /// The archive year.
        /// </param>
        /// <param name="archiveMonth">
        /// The archive month.
        /// </param>
        /// <returns>
        /// The blog posts.
        /// </returns>
        public IEnumerable<BlogPost> GetArchivedBlogPosts(string blogUrl, int archiveYear, string archiveMonth)
        {
            return
                this.GetArchivedBlogPosts(blogUrl, archiveYear).Where(
                    x => x.PostDate.ToString("MMMM").Equals(archiveMonth, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// The get blog.
        /// </summary>
        /// <param name="url">
        /// The requested blog's url.
        /// </param>
        /// <returns>
        /// The requested blog.
        /// </returns>
        public Blog GetBlog(string url)
        {
            var blogUrlSpecification = this.blogSpecificationFactory.GetBlogUrlSpecification(url);
            return this.cachingProvider.TryGet(
                blogUrlSpecification.CacheKey, () => this.blogRepository.FindOne(blogUrlSpecification));
        }

        /// <summary>
        /// The get latest blogs.
        /// </summary>
        /// <returns>
        /// A list of blogs.
        /// </returns>
        public IQueryable<Blog> GetLatestBlogs()
        {
            var latestBlogSpecifation = this.blogSpecificationFactory.GetLatestBlogSpecification();
            return this.cachingProvider.TryGet(
                latestBlogSpecifation.CacheKey, () => this.blogRepository.FindAll(latestBlogSpecifation));
        }

        /// <summary>
        /// The blog post save.
        /// </summary>
        /// <param name="blog">
        /// The blog to which the post is to be added.
        /// </param>
        /// <param name="blogPostSaveDetails">
        /// The blog post save details.
        /// </param>
        public void Save(Blog blog, BlogPostSaveDetails blogPostSaveDetails)
        {
            blogPostSaveDetails.Validate();

            var blogPost = GetBlogPostToUpdate(blog, blogPostSaveDetails.Url);

            if (blogPost == null)
            {
                blogPost = this.blogPostMapper.MapFrom(blogPostSaveDetails, new BlogPost());
                blogPost.Blog = blog;
                blog.BlogPosts.Add(blogPost);
            }
            else
            {
                var blodPostIndex = blog.BlogPosts.IndexOf(blogPost);

                blog.BlogPosts[blodPostIndex] = this.blogPostMapper.MapFrom(
                    blogPostSaveDetails, blog.BlogPosts[blodPostIndex]);
            }

            this.PerformSave(blog);
        }

        /// <summary>
        /// The blog save.
        /// </summary>
        /// <param name="blog">
        /// The blog to save.
        /// </param>
        /// <param name="postCommentSaveDetails">
        /// The post comment save details.
        /// </param>
        public void Save(Blog blog, BlogPostCommentSaveDetails postCommentSaveDetails)
        {
            postCommentSaveDetails.Validate();

            var blogPost = GetBlogPostToUpdate(blog, postCommentSaveDetails.PostUrl);

            var blogPostComment = this.blogPostCommentMapper.MapFrom(postCommentSaveDetails);

            blogPostComment.BlogPost = blogPost;

            blogPost.Comments.Add(blogPostComment);

            this.PerformSave(blog);
        }

        /// <summary>
        /// The blog details save method.
        /// </summary>
        /// <param name="blogSaveDetails">
        /// The blog save details.
        /// </param>
        public void Save(BlogSaveDetails blogSaveDetails)
        {
            blogSaveDetails.Validate();

            var blog = this.blogMapper.MapFrom(blogSaveDetails);
            blog.Author = this.identityService.GetCurrentUser();

            this.PerformSave(blog);
        }

        /// <summary>
        /// The get blog post to update.
        /// </summary>
        /// <param name="blog">
        /// The current blog.
        /// </param>
        /// <param name="blogPostUrl">
        /// The blog url.
        /// </param>
        /// <returns>
        /// The blog post to update.
        /// </returns>
        private static BlogPost GetBlogPostToUpdate(Blog blog, string blogPostUrl)
        {
            return
                blog.BlogPosts.SingleOrDefault(
                    x => x.Url.Equals(blogPostUrl, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// The perform save.
        /// </summary>
        /// <param name="blog">
        /// The blog to save.
        /// </param>
        private void PerformSave(Blog blog)
        {
            if (blog.Id > 0)
            {
                this.blogRepository.Update(blog);
            }
            else
            {
                this.blogRepository.Save(blog);
            }

            this.cachingProvider.Remove(blog.Author.Username);
            this.cachingProvider.Remove(blog.Url);
            this.cachingProvider.ResetDependenciesOn(CacheDependencies.Web);
        }
    }
}