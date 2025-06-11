using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Domain.Dto;
using INDT.TravelRoute.Domain.Entities;

namespace INDT.TravelRoute.Application.Interfaces.Services;

public interface IBestTravelRouteService
{
    CheapestTravelRouteResponse? FindBestRoute(IEnumerable<RoutesDto> routes, string from, string to);
}
