using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IService service;
        private readonly ILoggerManager loggerManager;

        public CompaniesController(IService service, ILoggerManager loggerManager)
        {
            this.service = service;
            this.loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult GetComapanies()
        {
            try
            {
                loggerManager.LogInfo("GettAllComapnies method is calling");

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
