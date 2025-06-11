namespace INDT.TravelRoute.Application.UseCases;

using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Domain.Interfaces.Repositories;

public class DeleteRouteUseCase : IDeleteRouteUseCase
{
    private readonly IRouteCrudRepository _repository;

    public DeleteRouteUseCase(IRouteCrudRepository repository)
    {
        _repository = repository;
    }

    public Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }
}
