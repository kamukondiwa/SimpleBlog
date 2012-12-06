namespace Leatn.Web.Controllers.Tag
{
    #region Using Directives

    using System.Web.Mvc;

    using Domain.Contracts.Tasks;

    using Mappers.Contracts;

    using Mvc.Attributes;
    using Mvc.Exceptions;

    using Shared.ActionResults;

    using ViewModels;

    #endregion

    public class TagController : Controller
    {
        private readonly ITagPageViewModelMapper tagPageViewModelMappper;

        private readonly ITagTasks tagTasks;

        public TagController(
            ITagTasks tagTasks, ITagPageViewModelMapper tagPageViewModelMappper)
        {
            this.tagTasks = tagTasks;
            this.tagPageViewModelMappper = tagPageViewModelMappper;
        }

        [WebOutputCacheAttrribute(VaryByParam = "tagId")]
        public ActionResult Tags(int? tagId)
        {
            TagPageViewModel pageViewModel;

            try
            {
                var taxonomyNode = this.tagTasks.GetTagById(tagId ?? 1);

                pageViewModel = this.tagPageViewModelMappper.MapFrom(taxonomyNode);
            }
            catch (NotFoundException)
            {
                return new NotFoundResult();
            }

            return this.View(pageViewModel);
        }
    }
}