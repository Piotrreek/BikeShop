using BikeShop.Entities;
using MediatR;

namespace BikeShop.Queries;

public class GetCategoriesByCategoryTypeQuery : IRequest<List<Category>>
{
    public GetCategoriesByCategoryTypeQuery(int categoryId)
    {
        CategoryId = categoryId;
    }

    public int CategoryId { get; }
}