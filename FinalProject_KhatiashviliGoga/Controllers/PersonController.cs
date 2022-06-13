using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Models;
using Microsoft.AspNetCore.Mvc;
using MyFirstProjectMVC1.Models;

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

            IEnumerable<Person> persons = _personService.GetPersons();
            return View(persons);
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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var getPersonResponse = _personService.GetPerson(new GetPersonRequest() { Id = (int)id });

            if (getPersonResponse == null)
            {
                return NotFound();
            }

            return View(getPersonResponse.Person);
        }


    }
}
