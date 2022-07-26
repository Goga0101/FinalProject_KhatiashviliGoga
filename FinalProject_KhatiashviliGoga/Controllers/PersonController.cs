using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Models;
using FinalProject_KhatiashviliGoga.Models.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FinalProject_KhatiashviliGoga.Controllers
{
    public class PersonController : Controller
    {
        private readonly IHostingEnvironment _environment;

       
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService, IHostingEnvironment e)
        {
            _personService = personService;
            _environment = e;
        }

        public IActionResult AllPersons()
        {
           
            IEnumerable<PersonModel> persons = _personService.GetPersons();
            return View(persons);
        }



        public IActionResult ShowFields(string Image, IFormFile pic)
        {
            ViewData["fname"] = Image;
            if (pic != null)
            {
                var fileName = Path.Combine(_environment.WebRootPath, Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = fileName;
                //ViewData["fileLocation"] ="/"+Path.GetFileName(pic.FileName); //Visual   
            }
            return View();
        }




        //GET
        public IActionResult Create(bool isSuccess = false , int organizationId = 0)
        {
            ViewBag.OrganizationId = new List<string>() { " 1 ", "2 ", "3 " };


            ViewBag.IsSuccess = isSuccess;
            ViewBag.OrganizationId = organizationId;
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
