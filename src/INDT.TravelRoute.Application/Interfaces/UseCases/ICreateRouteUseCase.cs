namespace INDT.TravelRoute.Application.Interfaces.UseCases;

using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Application.UseCases;
using INDT.TravelRoute.Domain.Entities;
using MediatR;

public interface ICreateRouteUseCase
{
    Task<Routes> ExecuteAsync(Routes route, CancellationToken cancellationToken);
}
