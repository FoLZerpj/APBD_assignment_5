namespace APBD_assignment_5;

using System.Data.SqlClient;

public class AnimalsController
{
    private readonly SqlConnection _connection;

    public AnimalsController(string connectionString)
    {
        this._connection = new SqlConnection(connectionString);
        this._connection.Open();
    }

    public List<Animal> GetAnimals(AnimalOrderBy? orderBy)
    {
        string orderByChecked =
            orderBy switch
            {
                null => "Name",
                AnimalOrderBy.Name => "Name",
                AnimalOrderBy.Description => "Description",
                AnimalOrderBy.Category => "Category",
                AnimalOrderBy.Area => "Area",
                _ => throw new Exception()
            };
        SqlCommand command = new SqlCommand("SELECT * FROM ANIMAL ORDER BY " + orderByChecked + " ASC", this._connection);

        using SqlDataReader dataReader = command.ExecuteReader();
        List<Animal> animals = new List<Animal>();
        while (dataReader.Read())
        {
            int id = (int)dataReader.GetValue(0);
            string name = (string)dataReader.GetValue(1);
            string description = (string)dataReader.GetValue(2);
            string category = (string)dataReader.GetValue(3);
            string area = (string)dataReader.GetValue(4);
            animals.Add(new Animal(id, name, description, category, area));
        }
        return animals;
    }

    public void AddAnimal(AnimalNoId animal)
    {
        SqlCommand command = new SqlCommand("INSERT INTO ANIMAL (Name, Description, Category, Area) VALUES (@name, @description, @category, @area)", this._connection);
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);
        command.ExecuteNonQuery();
    }

    public void UpdateAnimal(int animalId, AnimalNoId animal)
    {
        SqlCommand command = new SqlCommand("UPDATE ANIMAL SET Name = @name, Description = @description, Category = @category, Area = @area WHERE idAnimal = @idAnimal", this._connection);
        command.Parameters.AddWithValue("@idAnimal", animalId);
        
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);
        command.ExecuteNonQuery();
    }

    public void DeleteAnimal(int animalId)
    {
        SqlCommand command = new SqlCommand("DELETE FROM ANIMAL WHERE idAnimal = @idAnimal", this._connection);
        command.Parameters.AddWithValue("@idAnimal", animalId);
        command.ExecuteNonQuery();
    }
}