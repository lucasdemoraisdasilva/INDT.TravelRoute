using INDT.TravelRoute.Domain.Dto;
namespace INDT.TravelRoute.Infrastructure.SqlServer.Repositories;

using INDT.TravelRoute.Domain.Interfaces.Repositories;
using INDT.TravelRoute.Domain.Interfaces.UoW;
using INDT.TravelRoute.Infrastructure.SqlServer.Constants;
using Dapper;

public class TravelRouteRepository : ITravelRouteRepository
{
    private readonly IDapperDbContext _context;

    public TravelRouteRepository(IDapperDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoutesDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Connection
            .QueryAsync<RoutesDto>(RoutesConstants.GetAllQuery);
    }
}
