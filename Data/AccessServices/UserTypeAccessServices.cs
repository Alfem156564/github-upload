namespace Data.AccessServices
{
    using Common.Enumerations;
    using Common.Models;
    using Data.Contracts;
    using Data.Models.Entities;

    public class UserTypeAccessServices : IUserTypeAccessServices
    {
        private readonly IDatabaseContext databaseContext;

        public UserTypeAccessServices(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public UserTypeEntity GetUserTypeById(string userTypeId) =>
            databaseContext.UserTypes
                .FirstOrDefault(userType => userType.Id.Equals(userTypeId));

        public List<UserTypeEntity> GetUserTypes() =>
            databaseContext.UserTypes
                .Where(userType => userType.IsEnabled)
                .ToList();

        public List<UserTypeEntity> GetUserTypesDisabled() =>
            databaseContext.UserTypes
                .Where(userType => !userType.IsEnabled)
                .ToList();

        public async Task<ManagerResult<UserTypeEntity>> UpdateUserTypeAsync(
            string userTypeId,
            string updatedByUserId,
            string name)
        {
            UserTypeEntity userType = databaseContext.UserTypes
                .FirstOrDefault(userType => userType.Id.Equals(userTypeId));

            if (userType == null)
            {
                return ManagerResult<UserTypeEntity>
                    .FromError(ErrorCodes.UserTypeNotFound);
            }

            UserTypeEntity otherUserType = databaseContext.UserTypes
               .FirstOrDefault(userType => userType.Name.Equals(name)
                    && userType.Id != userTypeId);

            if (otherUserType != null)
            {
                return ManagerResult<UserTypeEntity>
                    .FromError(ErrorCodes.UserTypeNameAlreadyExists);
            }

            userType.Name = name;
            userType.EditedDate = DateTime.UtcNow;
            userType.EditedBy = updatedByUserId;

            await databaseContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return ManagerResult<UserTypeEntity>
                .FromSuccess(userType);
        }

        public async Task<ManagerResult<UserTypeEntity>> CreateUserTypeAsync(
            string name,
            string createdBy)
        {
            try
            {
                var userType = databaseContext.UserTypes
               .FirstOrDefault(userType => userType.Name.Equals(name));

                if (userType != null)
                {
                    return ManagerResult<UserTypeEntity>
                        .FromError(ErrorCodes.UserTypeNameAlreadyExists);
                }

                userType = new UserTypeEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    IsEnabled = true,
                    CreatedBy = createdBy
                };

                await databaseContext.UserTypes
                    .AddAsync(userType)
                    .ConfigureAwait(false);

                await databaseContext
                    .SaveChangesAsync()
                    .ConfigureAwait(false);

                return ManagerResult<UserTypeEntity>
                    .FromSuccess(userType);
            }catch (Exception ex)
            {
                return ManagerResult<UserTypeEntity>
                        .FromError(ErrorCodes.Unknown);
            }
        }

        public async Task<ManagerResult<UserTypeEntity>> DisabledUserTypeAsync(
            string userTypeId,
            string disabledBy)
        {
            var userType = databaseContext.UserTypes
               .FirstOrDefault(userType => userType.Id.Equals(userTypeId));

            if (userType == null)
            {
                return ManagerResult<UserTypeEntity>
                    .FromError(ErrorCodes.UserTypeNotFound);
            }

            userType.IsEnabled = !userType.IsEnabled;
            userType.DisabledDate = DateTime.UtcNow;
            userType.DisabledBy = disabledBy;

            await databaseContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            return ManagerResult<UserTypeEntity>
                .FromSuccess(userType);
        }
    }
}
