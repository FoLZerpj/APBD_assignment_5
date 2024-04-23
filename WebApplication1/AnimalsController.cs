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
}