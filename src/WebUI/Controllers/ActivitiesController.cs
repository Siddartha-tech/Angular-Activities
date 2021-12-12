using Application.Activities.Commands.CreateActivity;
using Application.Activities.Commands.DeleteActivity;
using Application.Activities.Commands.EditActivity;
using Application.Activities.Queries.GetActivities;
using Application.Activities.Queries.GetActivity;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
public class ActivitiesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> Get(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetActivitiesQuery(), cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
        return await Mediator.Send(new GetActivityDetailQuery { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] CreateActivityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActivity(Guid id, [FromBody] EditActivityCommand command)
    {
        command.Id = id;
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteActivityCommand { Id = id }));
    }
}