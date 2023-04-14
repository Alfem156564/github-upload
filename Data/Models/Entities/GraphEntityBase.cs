namespace Data.Models.Entities
{
    public class GraphEntityBase
    {
        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsEnabled { get; set; } = true;
    }
}
