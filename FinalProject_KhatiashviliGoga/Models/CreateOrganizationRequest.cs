namespace FinalProject_KhatiashviliGoga.Models
{ 
    public class CreateOrganizationRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public Guid ParentId { get; set; }
    }
}