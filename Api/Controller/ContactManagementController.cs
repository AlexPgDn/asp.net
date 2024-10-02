using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : FundamentalController
{
    private readonly IPaginationStorage storage;

    public ContactManagementController(IPaginationStorage storage){
        
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult CreateContact([FromBody]Contact contact){
        Contact res = storage.Add(contact);
        if (contact != null) return Ok(contact);
        return Conflict("Trying to add existing contact");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts(){

        return Ok(storage.GetContacts());
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id){
    
        bool res = storage.Remove(id);
        if (res) return NoContent();
        return BadRequest("Not existing Id");

    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id){
        bool res  =  storage.Update(contactDto,id);
        if(res) return Ok();
        return Conflict("Trying to delete  not existing contact");
    }
    [HttpGet("contact/{id}")]
    public ActionResult<Contact> GetContactThroughId(int id){
        if (storage.GetContactById(id) == null) return NotFound();
        return Ok(storage.GetContactById(id));
    }
    [HttpGet("contacts/page")]
    public IActionResult GetContacts(int pageNumber = 1,int pageSize = 5){

        var (contacts,total) = storage.GetContacts(pageNumber,pageSize);
        var response = new{

                Contacts = contacts,
                TotalContacts = total,
                CurrentPage = pageNumber,
                PageSize = pageSize
        };
        return Ok(response);
        
    }
}