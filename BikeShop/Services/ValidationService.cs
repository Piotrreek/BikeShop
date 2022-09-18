using BikeShop.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Services;

public class ValidationService<T> : AbstractValidator<T>
{
    private readonly IValidator<T> _validator;

    public ValidationService(IValidator<T> validator)
    {
        _validator = validator;
    }
    
    public async Task<bool> ValidateAsync(T model, ModelStateDictionary modelState)
    {
        var validationResult = await _validator.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(modelState);
            return false;
        }

        return true;
    }
}