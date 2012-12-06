namespace Leatn.Web.Controllers.Tag
{
    #region Using Directives

    using System.Web.Mvc;

    using Domain.Contracts.Tasks;
    using Domain.Tags;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;
    using Machine.Specifications.Mvc;

    using Mappers.Contracts;

    using Rhino.Mocks;

    using ViewModels;

    #endregion

    public abstract class Context_for_taxonomy_controller : Specification<TagController>
    {
        protected static ITagTasks TheTagTasks;

        protected static ITagPageViewModelMapper TheTagViewModelMapper;

        private Establish context = () =>
            {
                TheTagTasks = DependencyOf<ITagTasks>();
                TheTagViewModelMapper = DependencyOf<ITagPageViewModelMapper>();
            };
    }

    public class When_the_taxonomy_is_requested_by_node_id : Context_for_taxonomy_controller
    {
        private static TagPageViewModel _expectedTagPageViewModel;

        private static ActionResult result;

        private static Tag tag;

        private static int tagId;

        private Establish context = () =>
            {
                tag = new Tag();
                TheTagTasks.Stub(x => x.GetTagById(tagId)).Return(tag);
                _expectedTagPageViewModel = new TagPageViewModel();
                TheTagViewModelMapper.Stub(x => x.MapFrom(tag)).Return(_expectedTagPageViewModel);
            };

        private Because of = () => { result = subject.Tags(tagId); };

        private It should_ask_the_taxonomy_page_view_model_mapper_to_map_the_view_model =
            () => TheTagViewModelMapper.AssertWasCalled(x => x.MapFrom(tag));

        private It should_ask_the_taxonomy_tasks_for_the_taxonomy_node_by_id =
            () => TheTagTasks.AssertWasCalled(x => x.GetTagById(tagId));

        private It should_return_the_taxonomy_node_view_model_to_the_view =
            () => result.ShouldBeAView().And().Model<TagPageViewModel>().ShouldBeTheSameAs(_expectedTagPageViewModel);
    }
}