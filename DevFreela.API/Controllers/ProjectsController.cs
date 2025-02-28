using DeveFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DeveFreela.API.Controllers
{
    [Route("api/projects")]
    
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService =  projectService;
            _mediator = mediator;
        }


        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {

            var getAllProjectsQuery = new GetAllProjectQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetProjectByIdQuery(Id);
            var projectDetails = await _mediator.Send(query);

            if (projectDetails == null)
            {
                return NotFound();
            }
            return Ok(projectDetails);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int Id, [FromBody] UpdateProjectCommand command)
        {
           

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteProjectCommand(Id);

            await _mediator.Send(command);
            
            return NoContent();
        }
        [HttpPost("{Id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment(int id,[FromBody] CreateCommentCommand command)
        {
            

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{Id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand (id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{Id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
  