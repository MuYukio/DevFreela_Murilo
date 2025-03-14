﻿using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;  
        
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetAllSkillsQuery();
            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
