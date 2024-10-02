
public class SqlitePaginationEfStorage : SqliteEfStorage, IPaginationStorage
{
    public SqlitePaginationEfStorage(SqlLiteDbContext context) 
    : base (context)
    {


    }
    public Contact GetContactById(int id)
    {
        return base.context.Contacts.FirstOrDefault(x => x.Id == id);
    }

    public (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize)
    {
        int total = base.context.Contacts.Count();
        List<Contact> contacts = base.context.Contacts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return (contacts, total);
    }
}