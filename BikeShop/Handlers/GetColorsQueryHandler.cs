using BikeShop.Entities;
using BikeShop.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Handlers;

public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, List<Color>>
{
    private readonly BikeShopContext _context;

    public GetColorsQueryHandler(BikeShopContext context)
    {
        _context = context;
    }

    public async Task<List<Color>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Colors.ToListAsync();
    }
}