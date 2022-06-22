namespace Test.Api.Helpers
{
    using Data.Models.Entities;
    using Test.Api.Definition;

    public static class EntityHelpers
    {

        public static UserTypeDefinition ToDefinition(this UserTypeEntity userTypeEntity)
        {
            if (userTypeEntity == null)
            {
                return null;
            }
            return new UserTypeDefinition
            {
                Id = userTypeEntity.Id,
                Name = userTypeEntity.Name
            };
        }

        public static List<UserTypeDefinition> ToListDefinition(this List<UserTypeEntity> entities, bool onlyActive = false) =>
            (onlyActive) ? (entities ?? Enumerable.Empty<UserTypeEntity>()).Where(entity => entity.IsEnabled).Select(ToDefinition).ToList()
            : (entities ?? Enumerable.Empty<UserTypeEntity>()).Select(ToDefinition).ToList();

    }
}
