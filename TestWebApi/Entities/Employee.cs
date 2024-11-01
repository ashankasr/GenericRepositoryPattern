using TestWebApi.Entities.Base;

namespace TestWebApi.Entities;

public class Employee : AuditableEntity
{
    public string FirstName { get; set; }

    private Employee(string firstName)
    {
        FirstName = firstName;
    }

    public static Employee Create(string firstName)
    {
        return new Employee(firstName);
    }
}
