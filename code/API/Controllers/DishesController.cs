using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurents.Application.CQRS.Commands.CreateDish;
using Restaurents.Application.CQRS.Queries.GetAllDishes;
using Restaurents.Application.CQRS.Queries.GetDishById;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;
using Restaurents.Domain.Exceptions;
using Restaurents.Domain.RepositoryInterfaces;

namespace Restaurents.API.Controllers;

[ApiController]
[Route("api/restaurent/{restaurentId}/dishes/")]
public class DishesController(IMediator _mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurentId, [FromBody] CraeteNewDishCommand dishCommand)
    {
        try
        {
            dishCommand.RestaurentId = restaurentId;
            var response = await _mediator.Send(dishCommand);
            return Ok(response);
        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDishes([FromRoute] int restaurentId)
    {
        try
        {
            var dishes = await _mediator.Send(new GetAllDishesQuery(restaurentId));
            return Ok(dishes);
        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveDish([FromRoute] int restaurentId)
    {
        try
        {
            var response = await _mediator.Send(new DeletDishCommand(restaurentId));

            if (response)
            {
                return NoContent();
            }

            return BadRequest("not possible");
        }
        catch (Exception ex)
        {

            throw;
        }
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetDishById([FromRoute] int Id, [FromRoute] int restaurentId)
    {
        try
        {
            var response = await _mediator.Send(new GetDishByIdQuery(restaurentId, Id));
            return Ok(response);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
