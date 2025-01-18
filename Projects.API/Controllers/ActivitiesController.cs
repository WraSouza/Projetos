using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projects.Application.Commands.CreateActivity;
using Projects.Application.Queries.GetAllActivities;

namespace Projects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivityCommand command)
        {
            if (command is null)
                return BadRequest();

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivitiesAsync()
        {
            var allActivities = new GetAllActivitiesQuery();

            var activities = await mediator.Send(allActivities);

            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

    }
}
