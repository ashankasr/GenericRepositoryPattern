namespace GenericRepositoryPattern.Entities.Base;

public abstract class AuditableEntity : Entity<Guid>, ISoftDelete
{
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public string CreatedBy { get; set; } = string.Empty;
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
