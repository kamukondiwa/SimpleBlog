namespace Leatn.Web.Controllers.Tag.Mappers
{
    #region Using Directives

    using Contracts;

    using Domain.Tags;

    using ViewModels;

    #endregion

    public class TagPageViewModelMapper : ITagPageViewModelMapper
    {
        public TagPageViewModel MapFrom(Tag tag)
        {
            return new TagPageViewModel { Tag = tag };
        }
    }
}