using System.Data;
using FluentValidation;

namespace BikeShop.Models.Validators;

public class CreateProductViewModelValidator<T> : AbstractValidator<T> where T : CreateProductViewModel
{
    public CreateProductViewModelValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Insert name of product!");
        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Insert positive value bigger than 0!")
            .GreaterThan(0).WithMessage("Value must be positive!")
            .ScalePrecision(2, 18, true).WithMessage("Maximum precision of this field is 2!");
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Insert description of the product!");
        RuleFor(p => p.AvailableQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("This value cannot be negative!");
        RuleFor(p => p.Brand)
            .NotEmpty().WithMessage("Insert brand of the product!");
        RuleFor(p => p.CategoryId).NotEmpty();
        
        RuleFor(p => p.FormPhotos)
            .Must(files =>
            {
                if (files == null) return true;
                foreach (var file in files)
                {
                    if ((file.ContentType == "image/jpeg" || file.ContentType.Equals("image/jpg") ||
                        file.ContentType.Equals("image/png")) == false) return false;
                }

                return true;
            })
            .WithMessage("Insert file with correct extension!");
    }
}