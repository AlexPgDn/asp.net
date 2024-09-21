using Bogus;
using Microsoft.Data.Sqlite;

public class FakerInitializer : IInitializer
{
    private string connectionstring;

    public FakerInitializer(string connectionstring)
    {
        this.connectionstring = connectionstring;
    }

    public void Initialize(){

        using var connection = new SqliteConnection(connectionstring);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS contacts(
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        email TEXT NOT NULL
        );";

        command.ExecuteNonQuery();
        command.CommandText = "Select count(*) from contacts";

        long count = (long)command.ExecuteScalar();
        if (count == 0){
            var faker = new Faker<Contact>("en")
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email());
            
            var contacts = faker.Generate(125);
            
            foreach(var item in contacts){

                command.CommandText = @$"
                INSERT INTO contacts (name,email) VALUES
                (@name,@email)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("name",item.Name);
                command.Parameters.AddWithValue("email",item.Email);
                command.ExecuteNonQuery();
            }

        }
    }
}