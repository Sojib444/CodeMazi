using Contracts;
using DataTransferObjects.ComapnyDTO;
using DataTransferObjects.ComapnyDTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("v1/api/[controller]")]
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
        public IActionResult GetCompanies()
        {

            var company = service.companyService.GetAllCompanies(false);

            return Ok(company);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetCompany(Guid Id)
        {
            var company = service.companyService.GetCompany(Id, false);

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CerateCompany([FromBody] CreateCompnyDTO createCompnyDTO)
        {
           var newCompany = service.companyService.CreateComany(createCompnyDTO);

            return Ok(newCompany);
        }
    }
}
