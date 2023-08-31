﻿using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]/{companyId}/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IService service;
        private readonly ILoggerManager loggerManager;

        public EmployeeController(IService service , ILoggerManager loggerManager)
        {
            this.service = service;
            this.loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult GetAllEmployees(Guid companyId)
        {
            var employees = service.employeeService.GetAllEmployessDto(companyId, false);

            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmploye(Guid companyId,Guid employeeId)
        {
            var employees = service.employeeService.GetEmployesDto(companyId, employeeId, false);

            return Ok(employees);
        }
    }
}