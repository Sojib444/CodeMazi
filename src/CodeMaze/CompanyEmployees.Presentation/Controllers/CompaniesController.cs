using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IService service;

        public CompaniesController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetComapanies()
        {
            try
            {
                var companies = service.companyService.GetAllCompanies(false);

                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal Server error");
            }
        }
    }
}
