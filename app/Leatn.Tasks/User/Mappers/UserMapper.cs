namespace Leatn.Tasks.User.Mappers
{
    using Contracts;

    using Domain.User;

    using Framework.Mapper;

    /// <summary>
    /// The user mapper.
    /// </summary>
    public class UserMapper : BaseMapper<UserSaveDetails, User>, IUserMapper
    {
    }
}