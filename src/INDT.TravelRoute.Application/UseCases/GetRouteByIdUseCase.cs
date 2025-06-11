using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Domain.Entities;
using INDT.TravelRoute.Domain.Interfaces.Repositories;
using System.Threading;

namespace INDT.TravelRoute.Application.UseCases;

public class GetRouteByIdUseCase : IGetRouteByIdUseCase
{
    private readonly IRouteCrudRepository _repository;

    public GetRouteByIdUseCase(IRouteCrudRepository repository)
    {
        _repository = repository;
    }

    public Task<Routes> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }
}
