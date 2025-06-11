using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace INDT.TravelRoute.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutesController : ControllerBase
{
    private readonly ICreateRouteUseCase _createUseCase;
    private readonly IDeleteRouteUseCase _deleteUseCase;
    private readonly IGetAllRoutesUseCase _getAllUseCase;
    private readonly IGetRouteByIdUseCase _getRouteByIdUseCase;
    private readonly IUpdateRouteUseCase _updateUseCase;
    private readonly IGetBestTravelRouteUseCase _getBestTravelRouteUseCase;

    public RoutesController(
        ICreateRouteUseCase createUseCase,
        IDeleteRouteUseCase deleteUseCase,
        IGetAllRoutesUseCase getAllUseCase,
        IGetRouteByIdUseCase getRouteByIdUseCase,
        IUpdateRouteUseCase updateUseCase,
        IGetBestTravelRouteUseCase getBestTravelRouteUseCase)
    {
        _createUseCase = createUseCase;
        _deleteUseCase = deleteUseCase;
        _getAllUseCase = getAllUseCase;
        _getRouteByIdUseCase = getRouteByIdUseCase;
        _updateUseCase = updateUseCase;
        _getBestTravelRouteUseCase = getBestTravelRouteUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RouteInputDto dto)
    {
        var route = new Routes
        {
            From = dto.From,
            To = dto.To,
            Value = dto.Value
        };
        var result = await _createUseCase.ExecuteAsync(route, CancellationToken.None);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var route = await _getRouteByIdUseCase.ExecuteAsync(id, CancellationToken.None);
        if (route == null)
            return NotFound();

        await _deleteUseCase.ExecuteAsync(id, CancellationToken.None);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _getAllUseCase.ExecuteAsync(CancellationToken.None);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] RouteInputDto dto)
    {
        var route = new Routes
        {
            Id = id,
            From = dto.From,
            To = dto.To,
            Value = dto.Value,
        };
        var result = await _updateUseCase.ExecuteAsync(route, CancellationToken.None);
        return Ok(result);
    }

    [HttpGet]
    [Route("BestRoute")]
    public async Task<IActionResult> Get([FromQuery] string from, [FromQuery] string to)
    {
        var result = await _getBestTravelRouteUseCase.ExecuteAsync(from, to, CancellationToken.None);
        if (result == null)
            return NotFound("Rota não encontrada.");

        return Ok(new
        {
            rota = string.Join(" - ", result.Route),
            custo = result.Cost
        });
    }
}
