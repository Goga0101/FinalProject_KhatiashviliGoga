using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Mapping;
using FinalProject_KhatiashviliGoga.Models;
using Microsoft.EntityFrameworkCore;
using MyFirstProjectMVC1.Models;

namespace FinalProject_KhatiashviliGoga.Services
{


    public class PersonService : IPersonService
    {
        private readonly FinalProject_KhatiashviliGogaContext _context;
        private readonly IMapper<Entities.Person, PersonModel> _personMapper;

        public PersonService(FinalProject_KhatiashviliGogaContext context)
        {
            _personMapper = new PersonMapper();
            _context = context;
        }

        public CreatePersonResponse CreatePerson(PersonModel person)
        {
            var personAlreadyExists = _context.Persons.Any(p => p.Id == person.Id);

            if (personAlreadyExists)
            {
                throw new DbUpdateException($"person with id '{person.Id}' already exist.");
            }

            var personEntity = _personMapper.MapFromModelToEntity(person);

            var newPerson = _context.Persons.Add(personEntity);

            _context.SaveChanges();

            return new CreatePersonResponse { CreatedPerson = person };
        }

        public GetPersonResponse GetPerson(GetPersonRequest getPersonRequest)
        {
            var person = _context.Persons.Find(getPersonRequest.Id); // get from base, we have entity type object
            var personModel = _personMapper.MapFromEntityToModel(person); // using mapper to get category Model
            var response = new GetPersonResponse { Person = personModel };

            return response;

        }


        public IEnumerable<Person> GetPersons()
        {    
              return _context.Persons;
        }
    }

}