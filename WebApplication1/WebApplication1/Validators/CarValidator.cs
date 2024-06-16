using FluentValidation;
using WebApplication1.Models;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(x => x.Make).NotEmpty().WithMessage("Make is required");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");
        RuleFor(x => x.Year).GreaterThan(1900).WithMessage("Year must be greater than 1900");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
