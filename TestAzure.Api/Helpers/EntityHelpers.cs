namespace TestAzure.Api.Helpers
{
    using Data.Models.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using TestAzure.Api.Definition;

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

        public static CatalogoDestinoDefinition ToDefinition(this CatalogoDestinoEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new CatalogoDestinoDefinition
            {
                TipoCatalogoDestinoKey = entity.intTipoCatalogoDestinoKey,
                Descripcion = entity.vchDescripcion
            };
        }

        public static List<CatalogoDestinoDefinition> ToListDefinition(this List<CatalogoDestinoEntity> entities, bool onlyActive = false) =>
            (onlyActive) ? (entities ?? Enumerable.Empty<CatalogoDestinoEntity>()).Where(entity => entity.bitActivo).Select(ToDefinition).ToList()
            : (entities ?? Enumerable.Empty<CatalogoDestinoEntity>()).Select(ToDefinition).ToList();

    }
}
