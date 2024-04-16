namespace APBD_assignment_4;

public class Animal
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public AnimalCategory Category { get; set; }
    public float Weight { get; set; }
    public string FurColor { get; set; }

    private static int _nextId = 0;
    private int NextId
    {
        get
        {
            int ret = _nextId;
            _nextId += 1;
            return ret;
        }
    }

    public Animal(string name, AnimalCategory category, float weight, string furColor)
    {
        this.Id = NextId;
        this.Name = name;
        this.Category = category;
        this.Weight = weight;
        this.FurColor = furColor;
    }
}