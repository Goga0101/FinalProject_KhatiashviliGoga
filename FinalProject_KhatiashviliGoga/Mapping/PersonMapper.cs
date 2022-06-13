using FinalProject_KhatiashviliGoga;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Models;

namespace FinalProject_KhatiashviliGoga.Mapping
{
    public class PersonMapper : IMapper<Entities.Person, PersonModel>
    {
        public PersonModel MapFromEntityToModel(Entities.Person source) => new PersonModel
        {
            Id = source.Id,
            Name = source.Name,
            LastName = source.LastName,
            DateOfBirth = source.DateOfBirth,
            Language = source.Language,
            Image = source.Image,
            PersonalNumber = source.PersonalNumber,
            OrganizationId = source.OrganizationId,
            Organization = source.Organization,
        };

        public Entities.Person MapFromModelToEntity(PersonModel source)
        {
            var entity = new Entities.Person();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(PersonModel source, Entities.Person target)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.LastName = source.LastName; 
            target.DateOfBirth = source.DateOfBirth;
            target.Language = source.Language;
            target.Image = source.Image;
            target.PersonalNumber = source.PersonalNumber;
            target.OrganizationId = source.OrganizationId;
            target.Organization = source.Organization;
        }
    }
}
