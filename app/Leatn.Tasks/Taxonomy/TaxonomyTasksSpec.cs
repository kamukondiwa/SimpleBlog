namespace Leatn.Tasks.Taxonomy
{
    #region Using Directives

    using System.Collections.Generic;

    using Domain.Tags;

    using Framework.Extensions;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    using Rhino.Mocks;

    using Web.Mvc.Caching.Contracts;

    #endregion

    public abstract class context_for_taxonomy_tasks : Specification<TagTasks>
    {
        protected static ICachingProvider the_caching_provider;

        private Establish context = () => the_caching_provider = DependencyOf<ICachingProvider>();
    }

    public class when_the_taxonomy_tasks_is_asked_to_get_taxonomy_node_by_id : context_for_taxonomy_tasks
    {
        private static int nodeId;

        private static Tag expectedTag;

        private static Tag result;
        
        private static Tag cachedRootTag;

        private Establish context = () =>
            {
                nodeId = 2500;
                expectedTag = new Tag();
                expectedTag.SetNonPublicProperty(x => x.Id, nodeId);

                cachedRootTag = new Tag{Children = new List<Tag>
                    {
                      expectedTag  
                    }};
                the_caching_provider.Stub(x => x.Get<Tag>()).Return(cachedRootTag);
            };

        private Because of = () => result = subject.GetTagById(nodeId);

        private It should_ask_the_caching_provider_for_the_cached_root_tag = () => the_caching_provider.AssertWasCalled(x => x.Get<Tag>());

        private It should_return_the_taxonomy_node_matching_the_node_id = () => result.ShouldBeTheSameAs(expectedTag);
    }
}