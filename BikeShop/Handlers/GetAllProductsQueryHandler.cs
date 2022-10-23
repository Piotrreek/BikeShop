using BikeShop.Models;
using BikeShop.Queries;
using BikeShop.Repositories;
using MediatR;

namespace BikeShop.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllProducts();
        var viewModel = products.Select(p => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            ThumbnailName = p.Photos.FirstOrDefault(photo => photo.IsThumbnail == true)?.PhotoPath ??
                            p.Photos.FirstOrDefault()?.PhotoPath ?? 
                            null,
            Type = p.Category.Type
        }).ToList();

        return viewModel;
    }
}