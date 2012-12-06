namespace Leatn.Web.Controllers.Tag.ViewModels
{
    #region Using Directives

    using Domain.Tags;

    using Shared.ViewModels;

    #endregion

    public class TagPageViewModel : PageViewModel
    {
        public Tag Tag { get; set; }
    }
}