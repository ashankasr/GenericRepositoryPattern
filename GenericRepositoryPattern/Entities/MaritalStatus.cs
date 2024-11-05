using GenericRepositoryPattern.Entities.Base;

namespace GenericRepositoryPattern.Entities;

public class MaritalStatus : LookupEntity
{
    public string Name { get; set; }

    private MaritalStatus(string name)
    {
        Name = name;
    }

    public static MaritalStatus Create(string name)
    {
        return new MaritalStatus(name);
    }
}
