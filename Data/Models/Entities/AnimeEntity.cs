namespace Data.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Anime", Schema = "Pasatiempo")]
    public class AnimeEntity : EntityBase
    {
        public string Name { get; set; }
    }
}
