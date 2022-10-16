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
    private readonly IAzureBlobService _azureBlobService;

    public GeyBikeByIdQueryHandler(IBikeRepository bikeRepository, IMapper mapper, IAzureBlobService azureBlobService)
    {
        _bikeRepository = bikeRepository;
        _mapper = mapper;
        _azureBlobService = azureBlobService;
    }

    public async Task<BikeViewModel> Handle(GetBikeByIdQuery request, CancellationToken cancellationToken)
    {
        var bike = await _bikeRepository.GetBikeById(request.Id);
        if (bike is null) return null;

        var viewModel = _mapper.Map<BikeViewModel>(bike);
        foreach (var photo in bike.Photos)
        {
            var photoName = photo.PhotoPath;
            var blobDto = await _azureBlobService.GetBlobContentAsync(photoName);
            using var memoryStream = new MemoryStream();
            await blobDto.Content.CopyToAsync(memoryStream);
            var imageDto = new ImageDto()
            {
                Name = blobDto.Name,
                ContentType = blobDto.ContentType,
                Source = memoryStream.ToArray()
            };
            viewModel.ImageSources.Add(imageDto);
            await memoryStream.DisposeAsync();
        }

        using var ms = new MemoryStream();
        var thumbnail = bike.Photos.FirstOrDefault(p => p.IsThumbnail == true);
        if (thumbnail is not null)
        {
            var blobDto = await _azureBlobService.GetBlobContentAsync(thumbnail.PhotoPath);
            await blobDto.Content.CopyToAsync(ms);
            var imageDto = new ImageDto()
            {
                Name = blobDto.Name,
                ContentType = blobDto.ContentType,
                Source = ms.ToArray()
            };
            viewModel.ThumbnailSource = imageDto;
            return viewModel;
        }

        if (viewModel.ImageSources.Count > 0)
        {
            viewModel.ThumbnailSource = viewModel.ImageSources[0];
            return viewModel;
        }

        viewModel.ThumbnailSource = null;
        return viewModel;
    }
}