namespace Leatn.Web.Controllers.User.Mappers
{
    #region Using Directives

    using Leatn.Domain.User;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.User.Mappers.Contracts;
    using Leatn.Web.Controllers.User.ViewModels;

    #endregion

    /// <summary>
    /// The user save details mapper.
    /// </summary>
    public class UserSaveDetailsMapper : BaseMapper<UserFormViewModel, UserSaveDetails>, IUserSaveDetailsMapper
    {
    }
}