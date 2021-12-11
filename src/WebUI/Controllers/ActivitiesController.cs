using Application.Activities.Queries.GetActivities;
using Application.Activities.Queries.GetActivity;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
public class ActivitiesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> Get()
    {
        return await Mediator.Send(new GetActivitiesQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
        return await Mediator.Send(new GetActivityDetailQuery { Id = id});
    }
}