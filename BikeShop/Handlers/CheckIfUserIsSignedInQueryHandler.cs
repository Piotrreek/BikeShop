using BikeShop.Entities;
using BikeShop.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BikeShop.Handlers;

public class CheckIfUserIsSignedInQueryHandler : IRequestHandler<CheckIfUserIsSignedInQuery, bool>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SignInManager<User> _signInManager;

    public CheckIfUserIsSignedInQueryHandler(IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _signInManager = signInManager;
    }

    public Task<bool> Handle(CheckIfUserIsSignedInQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_httpContextAccessor.HttpContext != null && _signInManager.IsSignedIn(_httpContextAccessor.HttpContext.User));
    }
}