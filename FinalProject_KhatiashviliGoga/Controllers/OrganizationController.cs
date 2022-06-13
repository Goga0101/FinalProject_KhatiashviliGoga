using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_KhatiashviliGoga.Controllers
{
    public class OrganizationController : Controller
    {


        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public IActionResult AllOrganizations()
        {

            IEnumerable<Organization> organizations = _organizationService.GetOrganizations();
            return View(organizations);
        }



        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(OrganizationModel organization)
        {
            CreateOrganizationResponse createOrganizationResponse = new CreateOrganizationResponse();

            if (ModelState.IsValid)
            {
                createOrganizationResponse = _organizationService.CreateOrganization(organization);
                return RedirectToAction("AllOrganizations");
            }
            return View(createOrganizationResponse.CreatedOrganization);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var getOrganizationResponse = _organizationService.GetOrganization(new GetOrganizationRequest() { Id = (int)id });

            if (getOrganizationResponse == null)
            {
                return NotFound();
            }

            return View(getOrganizationResponse.Organization);
        }

      
    }
}
