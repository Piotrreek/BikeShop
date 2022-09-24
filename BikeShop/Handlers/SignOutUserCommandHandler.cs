using BikeShop.Commands;
using BikeShop.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BikeShop.Handlers;

public class SignOutUserCommandHandler : IRequestHandler<SignOutUserCommand>
{
    private readonly SignInManager<User> _signInManager;

    public SignOutUserCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<Unit> Handle(SignOutUserCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
        return default;
    }
}