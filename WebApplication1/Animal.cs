namespace APBD_assignment_4;

public class Animal
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string Area { get; private set; }

    public Animal(int id, string name, string description, string category, string area)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Category = category;
        this.Area = area;
    }
}