using System.Data.SqlClient;
using System.Net;
using System.Security;
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

const string ConnectionString = "db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True";
var animalsController = new AnimalsController(ConnectionString);

app.MapGet("/api/animals", () => animalsController.getAnimals())
    .WithName("GetAnimals")
    .WithOpenApi();

/*
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
*/

app.Run();