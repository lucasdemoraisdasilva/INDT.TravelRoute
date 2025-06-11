using INDT.TravelRoute.Domain.Entities;

namespace INDT.TravelRoute.Domain.Interfaces.Repositories;

public interface IRouteCrudRepository
{
    Task<Routes> CreateAsync(Routes route, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    Task<Routes> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<Routes>> GetAllAsync(CancellationToken cancellationToken);

    Task<Routes> UpdateAsync(Routes route, CancellationToken cancellationToken);
}
