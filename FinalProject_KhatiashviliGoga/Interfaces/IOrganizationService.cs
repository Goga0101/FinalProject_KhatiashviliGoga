using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Models;

namespace FinalProject_KhatiashviliGoga.Interfaces
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetOrganizations();
        GetOrganizationResponse GetOrganization(GetOrganizationRequest request);
        CreateOrganizationResponse CreateOrganization(OrganizationModel request);
    }
}
