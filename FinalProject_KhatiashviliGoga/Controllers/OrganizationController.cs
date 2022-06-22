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

            IEnumerable<OrganizationModel> organizations = _organizationService.GetOrganizations();
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
        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            var getOrganizationResponse = _organizationService.GetOrganization(new GetOrganizationRequest() { Id = (Guid)id });

            if (getOrganizationResponse == null)
            {
                return NotFound();
            }

            return View(getOrganizationResponse.Organization);
        }

        //POST
        [HttpPost]
        public IActionResult Edit(OrganizationModel organization)
        {
            if (ModelState.IsValid)
            {
                _organizationService.UpdateOrganization(new UpdateOrganizationRequest() { OrganizationToUpdate = organization });
                return RedirectToAction("AllOrganizations");
            }
            return View(organization);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            var deleteOrganizationResponse = _organizationService.GetOrganization(new GetOrganizationRequest() { Id = (Guid)id });
            if (deleteOrganizationResponse == null)
            {
                return NotFound();
            }

            return View(deleteOrganizationResponse.Organization);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Guid? id)
        {
            var getOrganizationResponse = _organizationService.GetOrganization(new GetOrganizationRequest() { Id = (Guid)id });
            if (getOrganizationResponse == null)
            {
                return NotFound();
            }
            _organizationService.DeleteOrganization(new DeleteOrganizationRequest() { Id = (Guid)id });
            return RedirectToAction("AllOrganizations");

        }


    }
}
