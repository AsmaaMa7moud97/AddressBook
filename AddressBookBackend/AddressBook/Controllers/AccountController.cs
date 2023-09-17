using AddressBook.Application.Commands;
using AddressBook.Infrastructure.Models.InputModels;
using AddressBook.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public AccountController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.UserName, model.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new  { Email = user.Email, Id = user.Id, Token = user.Token });


        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Register(CreateNewEmployeeCommand command)
        {
            var userId = await _userService.Register(new RegisterModel
            {
                Email= command.Email,
                Password=command.Password
            }) ;
            if (userId != null)
            {
                command.UserId = userId.ToString();
                 await _mediator.Send(command);
                return Ok(userId);
            }
            else
            {
                return BadRequest();
            }
        }
     
    }
}