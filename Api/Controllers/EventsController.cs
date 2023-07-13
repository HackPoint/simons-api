using Api.Controllers.Base;
using Application.ArEvents.Commands.CreateArEvents;
using Application.ArEvents.Queries.GetArEvents;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class EventsController : ApiControllerBase {
    // GET all saved events in db
    [HttpGet]
    public async Task<ActionResult<ArEventVm>> Get() {
        return await Mediator.Send(new GetArEventsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateArEventCommand command) {
        return await Mediator.Send(command);
    }
}