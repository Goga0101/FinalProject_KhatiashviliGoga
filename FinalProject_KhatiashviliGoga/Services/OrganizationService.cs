using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Mapping;
using FinalProject_KhatiashviliGoga.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_KhatiashviliGoga.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly FinalProject_KhatiashviliGogaContext _context;
        private readonly IMapper<Entities.Organization, OrganizationModel> _organizationMapper;

        public OrganizationService(FinalProject_KhatiashviliGogaContext context)
        {
            _organizationMapper = new OrganizationMapper();
            _context = context;
        }

        public CreateOrganizationResponse CreateOrganization(OrganizationModel organization)
        {
            var organizationAlreadyExists = _context.Organizations.Any(p => p.Id == organization.Id);

            if (organizationAlreadyExists)
            {
                throw new DbUpdateException($"Organization with id '{organization.Id}' already exist.");
            }

            var organizationEntity = _organizationMapper.MapFromModelToEntity(organization);

            var newOrganization = _context.Organizations.Add(organizationEntity);

            _context.SaveChanges();

            return new CreateOrganizationResponse { CreatedOrganization = organization };
        }

        public GetOrganizationResponse GetOrganization(GetOrganizationRequest getOrganizationRequest)
        {
            var organization = _context.Organizations.Find(getOrganizationRequest.Id); // get from base, we have entity type object
            var organizationModel = _organizationMapper.MapFromEntityToModel(organization); // using mapper to get category Model
            var response = new GetOrganizationResponse { Organization = organizationModel };

            return response;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return _context.Organizations;
        }
    }
}
