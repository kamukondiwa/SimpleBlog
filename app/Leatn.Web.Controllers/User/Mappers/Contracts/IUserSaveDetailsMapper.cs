namespace Leatn.Web.Controllers.User.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.User;
    using Leatn.Framework.Mapper;
    using Leatn.Web.Controllers.User.ViewModels;

    #endregion

    /// <summary>
    /// The user save details mapper contract.
    /// </summary>
    public interface IUserSaveDetailsMapper : IMapper<UserFormViewModel, UserSaveDetails>
    {
    }
}