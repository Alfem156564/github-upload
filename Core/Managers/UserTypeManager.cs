namespace Core.Managers
{
    using Common.Models;
    using Core.Contracts;
    using Data.Contracts;
    using Data.Models.Entities;

    public class UserTypeManager : IUserTypeManager
    {
        private readonly IUserTypeAccessServices userTypeAccessServices;

        public UserTypeManager(IUserTypeAccessServices userTypeAccessServices)
        {
            this.userTypeAccessServices = userTypeAccessServices;
        }

        public UserTypeEntity GetUserTypeById(string userTypeId) =>
            userTypeAccessServices
                .GetUserTypeById(userTypeId);

        public List<UserTypeEntity> GetUserTypes() =>
            userTypeAccessServices
                .GetUserTypes();

        public List<UserTypeEntity> GetUserTypesDisabled() =>
            userTypeAccessServices
                .GetUserTypesDisabled();

        public async Task<ManagerResult<UserTypeEntity>> UpdateUserTypeAsync(
            string userTypeId,
            string updatedByUserId,
            string name)
        {
            return await userTypeAccessServices
                .UpdateUserTypeAsync(userTypeId, updatedByUserId, name);
        }

        public async Task<ManagerResult<UserTypeEntity>> CreateUserTypeAsync(
            string name,
            string createdBy)
        {
            return await userTypeAccessServices
                .CreateUserTypeAsync(name, createdBy);
        }

        public async Task<ManagerResult<UserTypeEntity>> DisabledUserTypeAsync(
            string userTypeId,
            string disabledBy)
        {
            return await userTypeAccessServices
               .DisabledUserTypeAsync(userTypeId, disabledBy);
        }
    }
}
