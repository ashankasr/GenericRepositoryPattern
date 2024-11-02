namespace TestWebApi.Entities.Base;

public abstract class LookupEntity : Entity<int>, ISoftDelete
{
    public bool IsDeleted { get; set; }
}
