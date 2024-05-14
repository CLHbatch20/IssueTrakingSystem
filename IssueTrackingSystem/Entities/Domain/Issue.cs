using IssueTrackingSystem.Entities.Enum;

namespace IssueTrackingSystem.Entities.Domain
{
    public class Issue : Auditables
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Guid CategoryId { get; set; } 
        public Guid ReporterId { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssigneeId { get; set;}
    }
}
