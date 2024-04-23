namespace APBD_assignment_4;

using System.Data.SqlClient;

public class AnimalsController
{
    private readonly SqlConnection _connection;

    public AnimalsController(string connectionString)
    {
        this._connection = new SqlConnection(connectionString);
        this._connection.Open();
    }

    public List<Animal> getAnimals()
    {
        SqlCommand command = new SqlCommand("SELECT * FROM ANIMAL", this._connection);
        SqlDataReader dataReader = command.ExecuteReader();
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

    public void addAnimal(AnimalNoId animal)
    {
        SqlCommand command = new SqlCommand("INSERT INTO ANIMAL (Name, Description, Category, Area) VALUES (@name, @description, @category, @area)", this._connection);
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);
        command.ExecuteNonQuery();
    }

    public void updateAnimal(int animalId, AnimalOptional animal)
    {
        SqlCommand command = new SqlCommand("UPDATE ANIMAL SET Name = @name, Description = @description, Category = @category, Area = @area WHERE idAnimal = @idAnimal", this._connection);
        command.Parameters.AddWithValue("@idAnimal", animalId);
        
        command.Parameters.AddWithValue("@name", animal.Name);
        command.Parameters.AddWithValue("@description", animal.Description);
        command.Parameters.AddWithValue("@category", animal.Category);
        command.Parameters.AddWithValue("@area", animal.Area);
        command.ExecuteNonQuery();
    }

    public void deleteAnimal(int animalId)
    {
        SqlCommand command = new SqlCommand("DELETE FROM ANIMAL WHERE idAnimal = @idAnimal", this._connection);
        command.Parameters.AddWithValue("@idAnimal", animalId);
        command.ExecuteNonQuery();
    }
}