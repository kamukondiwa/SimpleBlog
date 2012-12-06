namespace Leatn.Tasks.User.Mappers.Contracts
{
    #region Using Directives

    using Leatn.Domain.User;
    using Leatn.Framework.Mapper;

    #endregion

    /// <summary>
    /// The user mapper contract..
    /// </summary>
    public interface IUserMapper : IMapper<UserSaveDetails, User>
    {
    }
}