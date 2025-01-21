using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projects.Application.Commands.CreateUser;
using Projects.Application.Models.ViewModels;
using Projects.Application.Queries.GetAllUsers;
using Projects.Infrastructure.Auth;
using Projects.Infrastructure.Persistence;

namespace Projects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(IMediator mediator, IAuthService authService, ProjetoDbContext context) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            if (command is null)
            {
                return BadRequest();
            }           

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginInputModel model)
        {
            var hash = authService.ComputeHash(model.Password);

            var user = context.Users.SingleOrDefault(u => u.Password == hash && u.Email == model.Email);

            if (user is null)
            {
                return BadRequest();
            }

            var token = authService.GenerateToken(user.Email, user.Role);

            var viewModel = new LoginViewModel(token);            

            return Ok(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
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
