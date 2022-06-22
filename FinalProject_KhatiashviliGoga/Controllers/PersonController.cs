using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Models;
using FinalProject_KhatiashviliGoga.Models.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject_KhatiashviliGoga.Controllers
{
    public class PersonController : Controller
    {


        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult AllPersons()
        {
            ViewBag.ListSelectList = new SelectList(GetOrganizationLists(),"Id" , "Title");
            IEnumerable<PersonModel> persons = _personService.GetPersons();
            return View(persons);
        }

        private List<OrganizationList> GetOrganizationLists()
        {
            var list = new List<OrganizationList>();
            list.Add(new OrganizationList() { Id = 1, Title = "New Company1" });
            list.Add(new OrganizationList() { Id = 2, Title = "New Company2" });
            list.Add(new OrganizationList() { Id = 3, Title = "New Company3" });
            list.Add(new OrganizationList() { Id = 4, Title = "New Company4" });

            return list;
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        public IActionResult Create(PersonModel person)
        {
            CreatePersonResponse createPersonResponse = new CreatePersonResponse();

            if (ModelState.IsValid)
            {
                createPersonResponse = _personService.CreatePerson(person);
                return RedirectToAction("AllPersons");
            }
            return View(createPersonResponse.CreatedPerson);
        }



        //GET
        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            var getPersonResponse = _personService.GetPerson(new GetPersonRequest() { Id = (Guid)id });

            if (getPersonResponse == null)
            {
                return NotFound();
            }

            return View(getPersonResponse.Person);
        }



        //POST
        [HttpPost]
        public IActionResult Edit(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(new UpdatePersonRequest() { PersonToUpdate = person });
                return RedirectToAction("AllPersons");
            }
            return View(person);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            var deletePersonResponse = _personService.GetPerson(new GetPersonRequest() { Id = (Guid)id });
            if (deletePersonResponse == null)
            {
                return NotFound();
            }

            return View(deletePersonResponse.Person);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Guid? id)
        {
            var getPersonResponse = _personService.GetPerson(new GetPersonRequest() { Id = (Guid)id });
            if (getPersonResponse == null)
            {
                return NotFound();
            }
            _personService.DeletePerson(new DeletePersonRequest() { Id = (Guid)id });
            return RedirectToAction("AllPersons");

        }



    }
}
