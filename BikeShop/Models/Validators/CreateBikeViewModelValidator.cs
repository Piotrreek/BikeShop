using FluentValidation;

namespace BikeShop.Models.Validators;

public class CreateBikeViewModelValidator : CreateProductViewModelValidator<CreateBikeViewModel>
{
    public CreateBikeViewModelValidator()
    {
        RuleFor(b => b.ProductionYear)
            .NotEmpty().WithMessage("Insert production year!");
        
    }
}