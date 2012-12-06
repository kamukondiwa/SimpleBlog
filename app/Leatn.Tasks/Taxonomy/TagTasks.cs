namespace Leatn.Tasks.Taxonomy
{
    #region Using Directives

    using Domain.Contracts.Tasks;
    using Domain.Tags;

    using Gentax.Visitors.Querying;

    using Web.Mvc.Caching.Contracts;
    using Web.Mvc.Exceptions;

    #endregion

    public class TagTasks : ITagTasks
    {
        private readonly ICachingProvider cachingProvider;

        public TagTasks(ICachingProvider cachingProvider)
        {
            this.cachingProvider = cachingProvider;
        }

        public Tag GetTagById(int tagId)
        {
            var taxononomySearchVisitor = new FindFirstVisitor<Tag>(x => x.Id == tagId);

            var taxonomyRoot = this.cachingProvider.Get<Tag>();

            taxononomySearchVisitor.Visit(taxonomyRoot);

            if(taxononomySearchVisitor.Result == null)
            {
                throw new NotFoundException("Not Found.");
            }

            return taxononomySearchVisitor.Result;
        }
    }
}