namespace Data.Models.Entities
{
    using System;

    public class EntityBase
    {
        public string Id { get; set; }

        public string CreatedBy { get; set; }

        public string? EditedBy { get; set; } = null;

        public string? EnabledBy { get; set; } = null;

        public string? DisabledBy { get; set; } = null;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? EditedDate { get; set; } = null;

        public DateTime? EnabledDate { get; set; } = null;

        public DateTime? DisabledDate { get; set; } = null;

        public bool IsEnabled { get; set; }

    }
}
