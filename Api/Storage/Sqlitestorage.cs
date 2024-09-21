
using System.Text;
using Microsoft.Data.Sqlite;

public class Sqlitestorage : IStorage
{
    private readonly string connectionString ;
    public Sqlitestorage(string connectionString){
            this.connectionString = connectionString;
    }
    public bool Add(Contact contact)
    {
        using var connection  = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        string sb = "INSERT INTO contacts (name,email) VALUES (@name, @email)";
        command.CommandText = sb;
        command.Parameters.AddWithValue("@name",contact.Name);
        command.Parameters.AddWithValue("@email",contact.Email);
        return command.ExecuteNonQuery() > 0;
    }

    public Contact GetContactById(int id)
    {
        using var connection  = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"SELECT * from contacts WHERE id = {id}";
        
        using var reader = command.ExecuteReader();
        Contact contact = new Contact();
        while(reader.Read()){
                contact.Id = reader.GetInt32(0);
                contact.Name = reader.GetString(1);
                contact.Email = reader.GetString(2);
            };
        return contact;
    }

    public List<Contact> GetContacts()
    {
        var contacts = new List<Contact>();

        using var connection  = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * from contacts";

        using var reader = command.ExecuteReader();
        while(reader.Read()){
            contacts.Add(new Contact(){
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }
        return contacts;
    }

    public bool Remove(int id)
    {
       using var connection  = new SqliteConnection(connectionString);
       connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"DELETE  from contacts WHERE id = {id}";
        return command.ExecuteNonQuery() > 0;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        using var connection  = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = @$"
        UPDATE contacts
        SET name = '{contactDto.Name}', email = '{contactDto.EMail}'
        WHERE id = {id}";

        return command.ExecuteNonQuery() > 0;
    }
}