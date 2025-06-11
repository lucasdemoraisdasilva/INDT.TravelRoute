namespace INDT.TravelRoute.Application.Interfaces.UseCases;

public interface IDeleteRouteUseCase
{
    Task ExecuteAsync(Guid id, CancellationToken cancellationToken);
}
