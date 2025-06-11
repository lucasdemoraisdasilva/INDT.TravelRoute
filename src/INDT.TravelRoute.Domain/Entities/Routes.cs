namespace INDT.TravelRoute.Domain.Entities;

public class Routes
{
    public Guid Id { get; set; }

    public string? From { get; set; }

    public string? To { get; set; }

    public decimal? Value { get; set; }

    public DateTime InclusionDate { get; set; }

    public DateTime LastUpdateDate { get; set; }
}
