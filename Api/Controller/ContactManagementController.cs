using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : FundamentalController
{
    private readonly IStorage storage;

    public ContactManagementController(IStorage storage){
        
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult CreateContact([FromBody]Contact contact){
        bool res = storage.Add(contact);
        if (res) return Created("/contacts","success");
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
    [HttpGet("contact")]
    public ActionResult<Contact> GetContactThroughId(int id){
        if (storage.GetContactById(id) == null) return NotFound();
        return Ok(storage.GetContactById(id));
    }
}