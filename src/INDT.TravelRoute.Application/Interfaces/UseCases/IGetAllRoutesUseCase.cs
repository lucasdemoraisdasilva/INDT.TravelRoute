using INDT.TravelRoute.Domain.Entities;

namespace INDT.TravelRoute.Application.Interfaces.UseCases;

public interface IGetAllRoutesUseCase
{
    Task<IEnumerable<Routes>> ExecuteAsync(CancellationToken cancellationToken);
}
