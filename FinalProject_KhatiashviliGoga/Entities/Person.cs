using FinalProject_KhatiashviliGoga.Enums;

namespace FinalProject_KhatiashviliGoga.Entities
{
    public class Person
    {
        public Guid Id { get; set; }  
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string Image { get; set; }

        public Languages Language { get; set; }

        public int PersonalNumber { get; set; }

        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; }

    }
}
