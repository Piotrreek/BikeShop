using BikeShop.Enums;
using BikeShop.Extensions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using ValidationResult = BikeShop.Enums.ValidationResult;

namespace BikeShop.Services;

public interface IValidationService<in T>
{
    Task<ValidationResult> ValidateAsync(T model, ModelStateDictionary modelState);
}

public class ValidationService<T> : AbstractValidator<T>, IValidationService<T>
{
    private readonly IValidator<T> _validator;

    public ValidationService(IValidator<T> validator)
    {
        _validator = validator;
    }
    
    public async Task<ValidationResult> ValidateAsync(T model, ModelStateDictionary modelState)
    {
        var validationResult = await _validator.ValidateAsync(model);
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(modelState);
            return ValidationResult.Fail;
        }
        

        return ValidationResult.Success;
    }
}