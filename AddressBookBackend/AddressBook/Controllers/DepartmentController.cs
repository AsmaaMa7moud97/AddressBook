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
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateDepartment")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> Create(CreateNewDepartmentCommand command)
        {           
            return await _mediator.Send(command);
        }
        [Authorize]
        [HttpPut]
        [Route("EditDepartment")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> Edit(int id,EditDepartmentCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        [Authorize]
        [HttpPost]
        [Route("DeleteDepartment")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Delete(DeleteDepartmentCommand command)
        {
             await _mediator.Send(command);
            return Ok();
        }
        [Route("GetDepartments")]
        [HttpGet]
        public async Task<List<DepartmentModel>> GetDepartments()
        {
            var result = await _mediator.Send(new GetDepartmentsQuery());
            return result;
        }
    }
}