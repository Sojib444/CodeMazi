using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        public CompaniesController(ICompanyService companyService)
        {
            CompanyService = companyService;
        }

        public ICompanyService CompanyService { get; }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                return Ok(CompanyService.GetAllCompanies(false));
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
