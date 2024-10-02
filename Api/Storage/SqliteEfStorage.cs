
public class SqliteEfStorage : IStorage
{
    protected readonly SqlLiteDbContext context;
    public SqliteEfStorage (SqlLiteDbContext context){

        this.context = context;
    }

    public Contact Add(Contact contact)
    {
        context.Contacts.Add(contact);
        context.SaveChanges();
        return contact;
    }

    

     public List<Contact>GetContacts(){

        return context.Contacts.ToList();
    }

    public bool Remove(int id)
    {
        var contact = context.Contacts.Find(id);
        if(contact == null){
            return false;
        }
        context.Contacts.Remove(contact);
        context.SaveChanges();
        return true;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        var contact = context.Contacts.Find(id);
        if (contact == null){

            return false;
        }
        contact.Name = contactDto.Name;
        contact.Email = contactDto.EMail;
        context.SaveChanges();
        return true;
    }
}