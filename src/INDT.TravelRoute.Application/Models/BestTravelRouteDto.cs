namespace INDT.TravelRoute.Application.Models;

public record CheapestTravelRouteDto(string From, string To);
public record CheapestTravelRouteResponse(List<string> Route, decimal? Cost);
