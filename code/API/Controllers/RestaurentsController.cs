using System;
using System.Net.Http.Headers;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurents.Application.Commands;
using Restaurents.Application.Commands.DeleteRestaurent;
using Restaurents.Application.Commands.UpdateRestaurent;
using Restaurents.Application.DTOs;
using Restaurents.Application.Queries.GetAllRestaurents;
using Restaurents.Application.Queries.GetRestaurentById;
using Restaurents.Domain.Constents;
using Restaurents.Domain.Exceptions;
using SQLitePCL;

namespace Restaurents.Controllers;

[ApiController]
[Route("api/restaurents")]
[Authorize]
public class RestaurentsController(IMediator mediator, ILogger<RestaurentsController> _logger) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllRestaurents([FromQuery] GetAllRestaurentsQuery query)
    {
        _logger.LogInformation("GetAllRestaurents method called.");
        var res = await mediator.Send(query);

        _logger.LogInformation("Get all restaurents response @{1}", JsonSerializer.Serialize(res));

        return Ok(res);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurentById([FromRoute] int id)
    {
        var res = await mediator.Send(new GetRestaurentByIdQuery() { Id = id });
        if (res == null)
        {
            throw new NotFoundException($"Record with {id} Not Found");
        }
        return Ok(res);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner)]
    public async Task<IActionResult> CreateRestaurent([FromBody] CreateRestaurentCommand command)
    {
        var res = await mediator.Send(command);
        return CreatedAtAction(nameof(GetRestaurentById), new { id = res }, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurent([FromRoute] int id)
    {
        var res = await mediator.Send(new DeleteRestaurentCommnd(id));

        return res ? NoContent() : throw new NotFoundException($"Record with {id} Not Found");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRestaurent([FromBody] UpdateRestaurentCommand dto, [FromRoute] int id)
    {
        dto.Id = id;
        var res = await mediator.Send(dto);
        return Ok(res);
    }
}
