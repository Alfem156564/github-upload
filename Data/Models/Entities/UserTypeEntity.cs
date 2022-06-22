namespace Data.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserType")]
    public class UserTypeEntity : EntityBase
    {
        public string Name { get; set; }
    }
}
