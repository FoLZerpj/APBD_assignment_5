namespace APBD_assignment_5;

public class Animal(int id, string name, string description, string category, string area)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public string Category { get; private set; } = category;
    public string Area { get; private set; } = area;
}

public class AnimalNoId(string name, string description, string category, string area)
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public string Category { get; private set; } = category;
    public string Area { get; private set; } = area;
}