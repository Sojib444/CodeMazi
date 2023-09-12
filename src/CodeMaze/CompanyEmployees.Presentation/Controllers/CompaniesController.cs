using CompanyEmployees.Presentation.ModelBinders;
using Contracts;
using DataTransferObjects.ComapnyDTO;
using DataTransferObjects.ComapnyDTOs;
using DataTransferObjects.RequestFeatures;
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
        public IActionResult GetCompanies([FromQuery] ComapnyParameters companyParameters)
        {
            var company = service.companyService.GetAllCompanies(companyParameters, false);

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

        [HttpDelete("{id:guid}")]
        public IActionResult DeleCompany(Guid id)
        {
            service.companyService.DeleteComany(id, false);

            return NoContent();
        }

        [HttpGet("collection/{ids}", Name = "CompnyCollection")]
        public IActionResult GetCompanieyCollection([ModelBinder(BinderType =
                 typeof(ArrayModelBinder))]IEnumerable<Guid> ids, bool trakChange)
        {
            var companyCollection = service.companyService.GetAllCompanyCollection(ids, false);

            return Ok(companyCollection);
        }

        [HttpPost("collection")]
        public IActionResult CreateCompanieyCollection([FromBody] IEnumerable<CreateCompnyDTO> compnyDTOs)
        {
            var result = service.companyService.CreateCompnyCollection(compnyDTOs);

            return CreatedAtRoute("compnyDTOs", new { result.ids }, result.comapnies);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCompany(Guid id, [FromBody] UpdateCompanyDTO updateCompanyDTO)
        {
            service.companyService.UpdateCompany(id, updateCompanyDTO, true);

            return NoContent();
        }
    }
}
