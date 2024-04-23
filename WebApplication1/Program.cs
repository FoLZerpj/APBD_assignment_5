using System.Data.SqlClient;
using System.Net;
using System.Security;
using APBD_assignment_4;
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

const string ConnectionString = "db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True";
var animalsController = new AnimalsController(ConnectionString);

app.MapGet("/api/animals", () => animalsController.getAnimals())
    .WithName("GetAnimals")
    .WithOpenApi();

app.MapPost("/api/animals", ([FromBody] AnimalNoId animal) =>
    {
        animalsController.addAnimal(animal);
    })
    .WithName("AddAnimal")
    .WithOpenApi();

app.MapPut("/api/animals/{id:int}", (int id, [FromBody] AnimalOptional updatedAnimal) =>
    {
        animalsController.updateAnimal(id, updatedAnimal);
    })
    .WithName("EditAnimalById")
    .WithOpenApi();

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        animalsController.deleteAnimal(id);
    })
    .WithName("DeleteAnimalById")
    .WithOpenApi();

app.Run();