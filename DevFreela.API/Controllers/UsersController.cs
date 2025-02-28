using DeveFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeveFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var userViewModel = await _mediator.Send(query);
            
            if (userViewModel == null) return NotFound();

            return Ok(userViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        { 
            var LoginUserViewModel = await _mediator.Send(command);
            
            if (LoginUserViewModel == null)
            {
                return BadRequest();
            } 
                
            return Ok(LoginUserViewModel);
        }
         
    }
}
