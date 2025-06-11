namespace INDT.TravelRoute.Application.UseCases;

using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Domain.Entities;
using INDT.TravelRoute.Domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

public class CreateRouteUseCase : ICreateRouteUseCase
{
    private readonly IRouteCrudRepository _repository;

    public CreateRouteUseCase(IRouteCrudRepository repository)
    {
        _repository = repository;
    }

    public Task<Routes> ExecuteAsync(Routes route, CancellationToken cancellationToken)
    {
        return _repository.CreateAsync(route, cancellationToken);
    }
}
