using Microsoft.AspNetCore.Http.Features;

public class ContactsStorage
{
    private List<Contact> Contacts {get;set;}
    public ContactsStorage(){

        this.Contacts = new List<Contact>();

        for(int i = 0; i<=5;i++){

            this.Contacts.Add(new Contact(){

                    Id = i,
                    Name = $"FullName_{i}",
                    EMail = $"{Guid.NewGuid().ToString().Substring(0,5)}_{i}@insane.com" 
            });
        }

    }

    public List<Contact> Get(){
        
        return this.Contacts;

    }
    public bool Add(Contact contact){
        foreach (var item in Contacts)
        {
            if(contact.Id == item.Id) { 
                return false;     
            }
        }
        Contacts.Add(contact);
        return true; 
    }
    public bool Remove(int id){

        for(int i = 0; i < Contacts.Count;i++){

            if(Contacts[i].Id == id){
                Contacts.Remove(Contacts[i]);
                return true;

            }
        }
        return false;
    }
    public bool Update(ContactDto contactDto, int id)
    {

        Contact contact;

        for (int i = 0; i < Contacts.Count; i++)
        {

            if (Contacts[i].Id == id)
            {

                contact = Contacts[i];
                if (!String.IsNullOrEmpty(contactDto.EMail))
                {
                    contact.EMail = contactDto.EMail;
                }
                if (!String.IsNullOrEmpty(contactDto.Name))
                {
                    contact.Name = contactDto.Name;
                }
                return true;
            }
        }
        return false;
    }

    public Contact GetContactById(int id){

        foreach (var item in Contacts)
        {
            if(item.Id == id) return item;
        }
        return null;
    }
}