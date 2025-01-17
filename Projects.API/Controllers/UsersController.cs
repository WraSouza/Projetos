using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projects.Application.Commands.CreateUser;
using Projects.Application.Queries.GetAllUsers;

namespace Projects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = new GetAllUsersQuery();

            var users = await mediator.Send(allUsers);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var allUsers = new GetAllUsersQuery();

            var users = await mediator.Send(allUsers);

            return Ok(users);
        }
    }
}
