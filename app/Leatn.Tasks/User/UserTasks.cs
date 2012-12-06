namespace Leatn.Tasks.User
{
    #region Using Directives

    using System;
    using System.Security;
    using System.Threading;

    using Framework.Validation;

    using Leatn.Domain.Contracts.Repositories;
    using Leatn.Domain.Contracts.Services;
    using Leatn.Domain.Contracts.Tasks;
    using Leatn.Domain.User;
    using Leatn.Tasks.User.Mappers.Contracts;

    #endregion

    /// <summary>
    /// The user tasks.
    /// </summary>
    public class UserTasks : IUserTasks
    {
        /// <summary>
        /// The identity service.
        /// </summary>
        private readonly IIdentityService identityService;

        /// <summary>
        /// The user mapper.
        /// </summary>
        private readonly IUserMapper userMapper;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTasks"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="userMapper">
        /// The user mapper.
        /// </param>
        /// <param name="identityService">
        /// The identity Service.
        /// </param>
        public UserTasks(IUserRepository userRepository, IUserMapper userMapper, IIdentityService identityService)
        {
            this.userRepository = userRepository;
            this.userMapper = userMapper;
            this.identityService = identityService;
        }

        /// <summary>
        /// The user save.
        /// </summary>
        /// <param name="userSaveDetails">
        /// The user save details.
        /// </param>
        public void Save(UserSaveDetails userSaveDetails)
        {
            userSaveDetails.Validate();

            var user = this.userMapper.MapFrom(userSaveDetails);

            if (!this.UserExists(userSaveDetails))
            {
                user.PasswordSalt = this.identityService.AuthenticationService.CreateSalt();
                user.PasswordHash = this.identityService.AuthenticationService.GetPasswordHash(
                    userSaveDetails.Password, user.PasswordSalt);
                this.userRepository.Save(user);
            }
        }

        /// <summary>
        /// The sign on.
        /// </summary>
        /// <param name="signOnDetails">
        /// The sign on form view model.
        /// </param>
        public void SignOn(UserSignOnDetails signOnDetails)
        {
            signOnDetails.Validate();

            if (this.identityService.AuthenticateUser(signOnDetails))
            {
                this.identityService.SignOn(signOnDetails);
            }
            else
            {
                throw new SecurityException();
            }
        }

        /// <summary>
        /// The user exists.
        /// </summary>
        /// <param name="userSignOnDetails">
        /// The user sign on details.
        /// </param>
        /// <returns>
        /// The user exists check result.
        /// </returns>
        public bool UserExists(UserSignOnDetails userSignOnDetails)
        {
            if (userSignOnDetails == null)
            {
                return true;
            }

            return this.userRepository.FindUserByName(userSignOnDetails.Username) != null;
        }

        /// <summary>
        /// The sign off.
        /// </summary>
        public void SignOff()
        {
            this.identityService.SignOff();
        }
    }
}