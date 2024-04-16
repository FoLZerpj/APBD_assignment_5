namespace APBD_assignment_4;

public class AnimalVisit
{
    public DateTime DateOfVisit { get; private set; }
    public Animal Animal { get; private set; }
    public string Description { get; private set; }
    public float VisitPrice { get; private set; }

    public AnimalVisit(DateTime dateOfVisit, Animal animal, string description, float visitPrice)
    {
        this.DateOfVisit = dateOfVisit;
        this.Animal = animal;
        this.Description = description;
        this.VisitPrice = visitPrice;
    }
}