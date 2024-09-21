public interface IStorage
{

    List<Contact> GetContacts();
    bool Add(Contact contact);
    bool Remove(int id);
    bool Update(ContactDto contactDto, int id);
    Contact GetContactById(int id);
}