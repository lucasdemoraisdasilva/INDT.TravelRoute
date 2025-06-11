namespace INDT.TravelRoute.Application.Interfaces.UseCases;

using INDT.TravelRoute.Application.Models;

public interface IGetBestTravelRouteUseCase
{
    Task<CheapestTravelRouteResponse?> ExecuteAsync(string from, string to, CancellationToken cancellationToken);
}
