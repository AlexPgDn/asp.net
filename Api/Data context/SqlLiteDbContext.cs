using Microsoft.EntityFrameworkCore;

public class SqlLiteDbContext : DbContext
{
    public DbSet<Contact> Contacts{get; set;}
    public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options)
    {


    }
}