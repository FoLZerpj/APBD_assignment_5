using APBD_assignment_4;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var animals = new List<Animal>()
{
    new Animal("Name1", AnimalCategory.Cat, 1.0f, "white"),
    new Animal("Name2", AnimalCategory.Dog, 2.0f, "black"),
};

app.MapGet("/animals", () => animals)
    .WithName("GetAnimals")
    .WithOpenApi();

app.MapGet("/animals/{id:int}", (int id) =>
{
    return animals.First(animal => animal.Id == id);
})
    .WithName("GetAnimalById")
    .WithOpenApi();

app.MapPost("/animals", (string name, AnimalCategory animalCategory, float weight, string furColor) =>
{
    animals.Add(new Animal(name, animalCategory, weight, furColor));
})
    .WithName("AddAnimal")
    .WithOpenApi();

app.MapPut("/animals/{id:int}", (int id, string? name, AnimalCategory? animalCategory, float? weight, string? furColor) =>
    {
        Animal animal = animals.First(animal => animal.Id == id);
        if (name != null)
        {
            animal.Name = name;
        }
        if (animalCategory.HasValue)
        {
            animal.Category = animalCategory.Value;
        }
        if (weight.HasValue)
        {
            animal.Weight = weight.Value;
        }
        if (furColor != null)
        {
            animal.FurColor = furColor;
        }
    })
    .WithName("EditAnimalById")
    .WithOpenApi();

app.MapDelete("/animals/{id:int}", (int id) =>
{
    animals.Remove(animals.First(animal => animal.Id == id));
})
    .WithName("DeleteAnimalById")
    .WithOpenApi();

var visits = new List<AnimalVisit>()
{
    new AnimalVisit(DateTime.Now, animals[0], "Description1", 1.0f),
    new AnimalVisit(DateTime.Now, animals[1], "Description1", 2.0f),
};

app.MapGet("/visits", () => visits)
    .WithName("GetVisits")
    .WithOpenApi();

app.MapPost("/visits", (DateTime date, int animalId, string description, float visitPrice) =>
    {
        Animal animal = animals.First(animal => animal.Id == animalId);
        visits.Add(new AnimalVisit(date, animal, description, visitPrice));
    })
    .WithName("AddVisit")
    .WithOpenApi();

app.Run();