namespace TestWebApi.Entities.Base;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}
