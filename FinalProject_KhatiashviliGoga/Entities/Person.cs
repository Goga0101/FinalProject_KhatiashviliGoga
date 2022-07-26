using FinalProject_KhatiashviliGoga.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_KhatiashviliGoga.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        [MaxLength(20), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(20), MinLength(2)]

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]

        public string Image { get; set; }

        public Languages Language { get; set; }
        [StringLength(11)]

        public string PersonalNumber { get; set; }

        public Guid OrganizationId { get; set; }


        public Organization? Organization { get; set; }

    }
}
