namespace INDT.TravelRoute.Application.UseCases;

using INDT.TravelRoute.Application.Interfaces.Services;
using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Domain.Interfaces.Repositories;

public class GetBestTravelRouteUseCase : IGetBestTravelRouteUseCase
{
    private readonly ITravelRouteRepository _repository;
    private readonly IBestTravelRouteService _service;

    public GetBestTravelRouteUseCase(ITravelRouteRepository repository, IBestTravelRouteService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<CheapestTravelRouteResponse?> ExecuteAsync(string from, string to, CancellationToken cancellationToken)
    {
        var allRoutes = await _repository.GetAllAsync(cancellationToken);
        return _service.FindBestRoute(allRoutes, from, to);
    }
}
