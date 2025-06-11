namespace INDT.TravelRoute.Application.UseCases;

using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Domain.Entities;
using INDT.TravelRoute.Domain.Interfaces.Repositories;

public class GetAllRoutesUseCase : IGetAllRoutesUseCase
{
    private readonly IRouteCrudRepository _repository;

    public GetAllRoutesUseCase(IRouteCrudRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Routes>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}
