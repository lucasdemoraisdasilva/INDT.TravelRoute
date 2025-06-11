namespace INDT.TravelRoute.Infrastructure.SqlServer.Repositories;

using Dapper;
using INDT.TravelRoute.Domain.Entities;
using INDT.TravelRoute.Domain.Interfaces.Repositories;
using INDT.TravelRoute.Domain.Interfaces.UoW;
using INDT.TravelRoute.Infrastructure.SqlServer.Constants;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class RouteCrudRepository : IRouteCrudRepository
{
    private readonly IDapperDbContext _context;

    public RouteCrudRepository(IDapperDbContext context)
    {
        _context = context;
    }

    public async Task<Routes> CreateAsync(Routes route, CancellationToken cancellationToken)
    {
        return await _context.Connection
            .QuerySingleAsync<Routes>(RoutesConstants.InsertQuery, route, _context.Transaction);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _context.Connection
            .ExecuteAsync(RoutesConstants.DeleteQuery, new { Id = id }, _context.Transaction);
    }

    public async Task<Routes> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Connection
            .QueryFirstOrDefaultAsync<Routes>(RoutesConstants.GetByIdQuery, new { Id = id });
    }

    public async Task<IEnumerable<Routes>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Connection
            .QueryAsync<Routes>(RoutesConstants.GetAllQuery);
    }

    public async Task<Routes> UpdateAsync(Routes route, CancellationToken cancellationToken)
    {
        return await _context.Connection
            .ExecuteScalarAsync<Routes>(RoutesConstants.UpdateQuery, route, _context.Transaction);
    }
}
