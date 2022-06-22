namespace Core.Contracts
{
    using Common.Models;
    using Data.Models.Entities;

    public interface IUserTypeManager
    {
        UserTypeEntity GetUserTypeById(string userTypeId);

        List<UserTypeEntity> GetUserTypes();

        List<UserTypeEntity> GetUserTypesDisabled();

        Task<ManagerResult<UserTypeEntity>> UpdateUserTypeAsync(
            string userTypeId,
            string updatedByUserId,
            string name);

        Task<ManagerResult<UserTypeEntity>> CreateUserTypeAsync(
            string name,
            string createdBy);

        Task<ManagerResult<UserTypeEntity>> DisabledUserTypeAsync(
            string userTypeId,
            string disabledBy);
    }
}
