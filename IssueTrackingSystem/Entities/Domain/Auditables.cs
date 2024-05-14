namespace IssueTrackingSystem.Entities.Domain
{
    public abstract class Auditables
    {
        public Guid Id { get; set; } = new Guid();
    }
}
