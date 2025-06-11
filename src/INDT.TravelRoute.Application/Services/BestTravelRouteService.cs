using INDT.TravelRoute.Application.Interfaces.Services;
using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Domain.Dto;

namespace INDT.TravelRoute.Application.Services;

public class BestTravelRouteService : IBestTravelRouteService
{
    public CheapestTravelRouteResponse? FindBestRoute(IEnumerable<RoutesDto> routes, string from, string to)
    {
        var graph = new Dictionary<string, List<(string To, decimal? Cost)>>();

        foreach (var route in routes)
        {
            if (!graph.ContainsKey(route.From))
                graph[route.From] = new();

            graph[route.From].Add((route.To, route.Value));
        }

        List<string>? bestPath = null;
        decimal? bestCost = decimal.MaxValue;

        void DFS(string current, List<string> path, decimal? cost)
        {
            if (cost >= bestCost) return;
            if (current == to)
            {
                bestCost = cost;
                bestPath = new List<string>(path);
                return;
            }

            if (!graph.ContainsKey(current)) return;

            foreach (var (next, value) in graph[current])
            {
                if (!path.Contains(next))
                {
                    path.Add(next);
                    DFS(next, path, cost + value);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        DFS(from, new List<string> { from }, 0);

        return bestPath == null ? null : new CheapestTravelRouteResponse(bestPath, bestCost);
    }
}
