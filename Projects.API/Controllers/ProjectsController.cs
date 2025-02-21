using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projects.Application.Commands.CreateProject;
using Projects.Application.Commands.UpdateProject;
using Projects.Application.Queries.GetAllProjects;
using Projects.Infrastructure.Persistence;

namespace Projects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IMediator mediatR, ProjetoDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProjectCommand command)
        {
            if (command is null)
                return BadRequest();

            var id = await mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var getAllProjects = new GetAllProjectsQuery();

            var projects = await mediatR.Send(getAllProjects);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getAllProjects = new GetAllProjectsQuery();

            var projects = await mediatR.Send(getAllProjects);

            return Ok(projects);
        }

        [HttpPut("/finish-project")]
        public async Task<IActionResult> Finish([FromBody]UpdateProjectCommand command)
        {
            var project = new UpdateProjectCommand(command.Id);

            var id = await mediatR.Send(project);

            return NoContent();
        }

        [HttpPut("/delete-project")]
        public async Task<IActionResult> Delete()
        {           
            return NoContent();
        }
    }
}
