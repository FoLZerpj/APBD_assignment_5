using APBD_assignment_5;
using Microsoft.AspNetCore.Mvc;

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

const string ConnectionString = "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True";
var animalsController = new AnimalsController(ConnectionString);

app.MapGet("/api/animals", (AnimalOrderBy? orderBy) => animalsController.GetAnimals(orderBy))
    .WithName("GetAnimals")
    .WithOpenApi();

app.MapPost("/api/animals", ([FromBody] AnimalNoId animal) =>
    {
        animalsController.AddAnimal(animal);
    })
    .WithName("AddAnimal")
    .WithOpenApi();

app.MapPut("/api/animals/{id:int}", (int id, [FromBody] AnimalNoId updatedAnimal) =>
    {
        animalsController.UpdateAnimal(id, updatedAnimal);
    })
    .WithName("EditAnimalById")
    .WithOpenApi();

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        animalsController.DeleteAnimal(id);
    })
    .WithName("DeleteAnimalById")
    .WithOpenApi();

app.Run();