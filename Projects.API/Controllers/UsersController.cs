using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Projects.Application.Commands.CreateUser;
using Projects.Application.Models.InputModels;
using Projects.Application.Models.ViewModels;
using Projects.Application.Queries.GetAllUsers;
using Projects.Infrastructure.Auth;
using Projects.Infrastructure.Notifications;
using Projects.Infrastructure.Persistence;

namespace Projects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(IMediator mediator, IAuthService authService, ProjetoDbContext context, IMemoryCache cache, IEmailService emailService) : ControllerBase
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

        [HttpPost("/recovery-password/request")]
        [AllowAnonymous]
        public async Task<IActionResult> RecoveryPassword([FromBody] RecoveryPasswordInputModel model)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);

            if (user is null)
            {
                return BadRequest();
            }

            var code = new Random().Next(100000, 999999).ToString();

            var cacheKey = $"RecoveryCode: {model.Email}";

            cache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

            await emailService.SendAsync(user.Email, "Código de Recuperação", $"Seu Código de Recuperação é {code}");
           

            return NoContent();
        }

        [HttpPost("/recovery-password/validate-code")]
        [AllowAnonymous]
        public async Task<IActionResult> ValideteCode([FromBody] ValidateRecoveryInputModel model)
        {
            var cacheKey = $"RecoveryCode:{model.Email}";

            if (!cache.TryGetValue(cacheKey, out string? code) || code != model.Code)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost("/recovery-password/change-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordInputModel model)
        {
            var cacheKey = $"RecoveryCode:{model.Email}";

            if (!cache.TryGetValue(cacheKey, out string? code) || code != model.Code)
            {
                return BadRequest();
            }

            cache.Remove(cacheKey);

            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);

            if (user is null)
            {
                return BadRequest();
            }

            var hash = authService.ComputeHash(model.Password);

            user.UpdatePassword(hash);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
