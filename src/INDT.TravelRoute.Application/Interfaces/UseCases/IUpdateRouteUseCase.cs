using INDT.TravelRoute.Domain.Entities;

namespace INDT.TravelRoute.Application.Interfaces.UseCases;

public interface IUpdateRouteUseCase
{
    Task<Routes> ExecuteAsync(Routes route, CancellationToken cancellationToken);
}
