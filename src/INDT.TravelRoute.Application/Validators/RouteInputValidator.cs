namespace INDT.TravelRoute.Application.Validators;

using FluentValidation;
using INDT.TravelRoute.Application.Models;

public class RouteInputValidator : AbstractValidator<RouteInputDto>
{
    public RouteInputValidator()
    {
        RuleFor(x => x.From)
            .NotEmpty().Length(3);
        RuleFor(x => x.To)
            .NotEmpty().Length(3);
        RuleFor(x => x.Value)
            .GreaterThan(0);
    }
}
