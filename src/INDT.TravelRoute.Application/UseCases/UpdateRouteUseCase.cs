namespace INDT.TravelRoute.Application.UseCases;

using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Domain.Entities;
using INDT.TravelRoute.Domain.Interfaces.Repositories;

public class UpdateRouteUseCase : IUpdateRouteUseCase
{
    private readonly IRouteCrudRepository _repository;

    public UpdateRouteUseCase(IRouteCrudRepository repository)
    {
        _repository = repository;
    }

    public Task<Routes> ExecuteAsync(Routes route, CancellationToken cancellationToken)
    {
        return _repository.UpdateAsync(route, cancellationToken);
    }
}
