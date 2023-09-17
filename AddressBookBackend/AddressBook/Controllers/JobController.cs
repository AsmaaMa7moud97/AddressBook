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
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateJob")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> Create(CreateJobCommand command)
        {
            return await _mediator.Send(command);
        }
        [Authorize]
        [HttpPut]
        [Route("EditJob")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> Edit(int id,EditJobCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        [Authorize]
        [HttpPost]
        [Route("DeleteJob")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Delete(DeleteJobCommand command)
        {
          var res=  await _mediator.Send(command);
            return Ok(res);
        }
        [Route("GetJobs")]
        [HttpGet]
        public async Task<List<JobModel>> GetJobs()
        {
            var result = await _mediator.Send(new GetJobsQuery());
            return result;
        }

    }
}