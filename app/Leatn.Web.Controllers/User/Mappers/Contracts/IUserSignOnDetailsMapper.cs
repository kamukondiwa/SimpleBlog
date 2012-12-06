namespace Leatn.Web.Controllers.User.Mappers.Contracts
{
    using Domain.User;

    using Framework.Mapper;

    using ViewModels;

    /// <summary>
    /// The user sign on details mapper contract.
    /// </summary>
    public interface IUserSignOnDetailsMapper : IMapper<UserSignOnFormViewModel, UserSignOnDetails>
    {
    }
}