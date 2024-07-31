using FluentValidation;
using Restaurants.Application.Restaurants.DTO;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
{
    private readonly int[] allowedPageSizes = [5, 10, 15, 30];

    private readonly string[] allowedSortByColumnNames = [nameof(RestaurantDto.Name),
            nameof(RestaurantDto.Category), nameof(RestaurantDto.Description)];

    public GetAllRestaurantsQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .Must(value => allowedPageSizes.Contains(value))
            .WithMessage($"Page size must be: {string.Join(", ", allowedPageSizes)}");

        RuleFor(r => r.SortBy)
            .Must(value => allowedSortByColumnNames.Any(allowed =>
                    string.Equals(value, allowed, StringComparison.OrdinalIgnoreCase)))
            .When(q => q.SortBy != null)
            .WithMessage($"Sort by is optional, or must be: {string.Join(", ", allowedSortByColumnNames)}");
    }
}
