using AddressBook.Application;
using AddressBook.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Route("SearchEmployee")]
        [HttpGet]
        public async Task<List<EmployeeModel>> SearchEmployee(string FullName,string Email,string MobileNumber,int JobId,int DepartmentId)
        {
            var result = await _mediator.Send(new GetSearchEmployeesQuery() {
                FullName= FullName,Email=Email,MobileNumber=MobileNumber,
                JobTitleId=JobId,DepartmentId=DepartmentId
            });
            return result;
        }
        [AllowAnonymous]
        [HttpPost("ExportExcelSheet")]
        public async Task<FileContentResult> ExportExcelSheet()
        {
            var res = await _mediator.Send(new ExportFileCommand());
            return res;
        }

    }
}