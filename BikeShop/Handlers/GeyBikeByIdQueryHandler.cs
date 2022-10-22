using AutoMapper;
using BikeShop.Models;
using BikeShop.Queries;
using BikeShop.Repositories;
using BikeShop.Services;
using MediatR;

namespace BikeShop.Handlers;

public class GeyBikeByIdQueryHandler : IRequestHandler<GetBikeByIdQuery, BikeViewModel>
{
    private readonly IBikeRepository _bikeRepository;
    private readonly IMapper _mapper;

    public GeyBikeByIdQueryHandler(IBikeRepository bikeRepository, IMapper mapper)
    {
        _bikeRepository = bikeRepository;
        _mapper = mapper;
    }

    public async Task<BikeViewModel> Handle(GetBikeByIdQuery request, CancellationToken cancellationToken)
    {
        var bike = await _bikeRepository.GetBikeById(request.Id);
        if (bike is null) return null;

        var viewModel = _mapper.Map<BikeViewModel>(bike);
        foreach (var photo in bike.Photos)
        {
            if (photo.IsThumbnail is false)
                viewModel.ImageNames.Add(photo.PhotoPath);
            else
                viewModel.ThumbnailName = photo.PhotoPath;
        }
        return viewModel;
    }
}
