namespace TestWebApi.Entities.Base;

public abstract class AuditableEntity : Entity<Guid>
{
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public string CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}
