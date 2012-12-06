namespace Leatn.Web.Controllers.User.Mappers
{
    #region Using Directives

    using Leatn.Domain.User;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.User.Mappers.Contracts;
    using Leatn.Web.Controllers.User.ViewModels;

    #endregion

    /// <summary>
    /// The user sign on details mapper.
    /// </summary>
    public class UserSignOnDetailsMapper : BaseMapper<UserSignOnFormViewModel, UserSignOnDetails>, 
                                           IUserSignOnDetailsMapper
    {
    }
}