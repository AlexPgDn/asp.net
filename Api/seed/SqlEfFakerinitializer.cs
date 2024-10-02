using Bogus;
using Microsoft.EntityFrameworkCore;

public class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqlLiteDbContext context;

    public SqliteEfFakerInitializer(SqlLiteDbContext context)
    {
        this.context = context;
    }

    private string GenerateEmailForName(string name)
    {
        string email = name
            .ToLower()
            .Replace(" ", ".") + "@example.com";

        return email;
    }
    public void Initialize()
    {
        context.Database.Migrate();
        if (!context.Contacts.Any())
        {
            var faker = new Faker<Contact>("en")
                    .RuleFor(c => c.Name, f => f.Name.FullName())
                     .RuleFor(c => c.Email, (f, c) => GenerateEmailForName(c.Name));

            var contacts = faker.Generate(20);

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
}