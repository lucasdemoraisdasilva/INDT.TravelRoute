using INDT.TravelRoute.Domain.Dto;
using INDT.TravelRoute.Domain.Entities;
using System.Diagnostics;

namespace INDT.TravelRoute.Domain.Interfaces.Repositories;

public interface ITravelRouteRepository
{
    Task<IEnumerable<RoutesDto>> GetAllAsync(CancellationToken cancellationToken);
}
