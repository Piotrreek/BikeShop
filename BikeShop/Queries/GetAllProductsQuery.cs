using BikeShop.Models;
using MediatR;

namespace BikeShop.Queries;

public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
{
    
}