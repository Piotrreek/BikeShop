using BikeShop.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Commands;

public class RegisterUserCommand : IRequest<bool>
{
    public UserViewModel Model { get; }
    public ModelStateDictionary ModelState { get; }

    public RegisterUserCommand(UserViewModel model, ModelStateDictionary modelState)
    {
        Model = model;
        ModelState = modelState;
    }
}