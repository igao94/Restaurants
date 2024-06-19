using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories =
        ["Italian", "Mexican", "Japanese", "American", "Indian"];

    public CreateRestaurantCommandValidator()
    {
        RuleFor(command => command.Name)
            .Length(3, 100);

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(command => command.Category)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please choose from the valid categories.");

        RuleFor(command => command.ContactEmail)
            .EmailAddress()
            .WithMessage("Please provide a valid email address.");

        RuleFor(command => command.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please provide a valid postal code(XX - XXX).");
    }
}
