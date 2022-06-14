using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Models;
using MyFirstProjectMVC1.Models;

namespace FinalProject_KhatiashviliGoga.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();
        GetPersonResponse GetPerson(GetPersonRequest request);
        CreatePersonResponse CreatePerson(PersonModel request);

        UpdatePersonResponse UpdatePerson(UpdatePersonRequest request);
        DeletePersonResponse DeletePerson(DeletePersonRequest request);
    }
}
