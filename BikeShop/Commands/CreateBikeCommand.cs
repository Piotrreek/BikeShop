using BikeShop.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BikeShop.Commands;

public class CreateBikeCommand : IRequest<bool>
{
    public CreateBikeCommand(CreateBikeViewModel model, ModelStateDictionary modelState)
    {
        Model = model;
        ModelState = modelState;
    }

    public CreateBikeViewModel Model { get; }
    public ModelStateDictionary ModelState { get; }
}