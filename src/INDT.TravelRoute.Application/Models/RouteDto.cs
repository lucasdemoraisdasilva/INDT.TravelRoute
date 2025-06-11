namespace INDT.TravelRoute.Application.Models;

public class RouteInputDto
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public decimal Value { get; set; }
}

public class RouteOutputDto
{
    public Guid Id { get; set; }
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime InclusionDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}
