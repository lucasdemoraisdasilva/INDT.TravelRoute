using INDT.TravelRoute.Domain.Entities;

namespace INDT.TravelRoute.Application.Interfaces.UseCases;

public interface IGetRouteByIdUseCase
{
    Task<Routes> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}
