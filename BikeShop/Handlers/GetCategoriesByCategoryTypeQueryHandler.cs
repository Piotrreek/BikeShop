using BikeShop.Entities;
using BikeShop.Queries;
using BikeShop.Repositories;
using MediatR;

namespace BikeShop.Handlers;

public class GetCategoriesByCategoryTypeQueryHandler : IRequestHandler<GetCategoriesByCategoryTypeQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesByCategoryTypeQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetCategoriesByCategoryTypeQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetCategoriesByCategoryTypeId(request.CategoryId);
    }
}