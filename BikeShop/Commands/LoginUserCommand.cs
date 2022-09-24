using BikeShop.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Commands;

public class LoginUserCommand : IRequest<bool>
{
    public LoginViewModel Model { get; }
    public ModelStateDictionary ModelState { get; }
    
    public LoginUserCommand(LoginViewModel model, ModelStateDictionary modelState)
    {
        Model = model;
        ModelState = modelState;
    }
}