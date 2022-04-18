using Microsoft.AspNetCore.Mvc;
using PhoneBookWeb.Models;
using PhoneBookWeb.Services;

namespace PhoneBookWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> ContactForm(int id = 0)
        {
            Contacts contacts = await _contactService.GetContactById(id) ?? new();

            return View(new Tuple<Contacts, bool>(contacts, id > 0));
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(BaseContact contact)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Enter required fields");

                bool status = await _contactService.CreateContact(contact);

                if (!status)
                {
                    return BadRequest("Duplicated phone no");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContact contact)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");

            int status = await _contactService.UpdateContact(contact);

            return status switch
            {
                0 => Ok(),
                1 => BadRequest("Phone book is deleted"),
                2 => BadRequest("Duplicated phone no"),
                _ => Ok()
            };
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(DeleteContact contact)
        {
            bool status = await _contactService.DeleteContact(contact);

            if (!status)
            {
                return BadRequest("Phonebook has been deleted");
            }

            return Ok();
        }

        public async Task<ActionResult> Contacts(ContactFilter filter)
        {
            try
            {
                IEnumerable<Contacts> contacts = await _contactService.GetContacts(filter);

                return View(new Tuple<IEnumerable<Contacts>, ContactFilter>(contacts, filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
