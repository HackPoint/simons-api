using Api.Controllers.Base;
using Application.ArEvents.Commands.CreateArEvents;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class EventsController : ApiControllerBase {
    // GET all saved events in db
    [HttpGet]
    public string Get() {
        return "pong";
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateArEventCommand command) {
        return await Mediator.Send(command);
    }
}