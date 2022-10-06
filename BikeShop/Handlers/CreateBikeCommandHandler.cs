using AutoMapper;
using BikeShop.Commands;
using BikeShop.Entities;
using BikeShop.Enums;
using BikeShop.Models;
using BikeShop.Repositories;
using BikeShop.Services;
using MediatR;

namespace BikeShop.Handlers;

public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, bool>
{
    private readonly IBikeRepository _bikeRepository;
    private readonly IPhotoRepository _photoRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IValidationService<CreateBikeViewModel> _validator;
    private readonly IMapper _mapper;

    public CreateBikeCommandHandler(IBikeRepository bikeRepository, IValidationService<CreateBikeViewModel> validator, IMapper mapper, ITagRepository tagRepository, IPhotoRepository photoRepository)
    {
        _bikeRepository = bikeRepository;
        _validator = validator;
        _mapper = mapper;
        _tagRepository = tagRepository;
        _photoRepository = photoRepository;
    }

    public async Task<bool> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Model, request.ModelState);
        if (validationResult == ValidationResult.Fail)
            return false;
        
        var bike = _mapper.Map<Bike>(request.Model);
        var tags = request.Model.TagList.Split(new[] { ',', ' ', ';' }).ToList();
        
        foreach (var tag in tags)
            bike.Tags.Add(await _tagRepository.InsertTag(tag));
        
        foreach (var photo in request.Model.FormPhotos ?? new FormFileCollection())
            bike.Photos.Add(await _photoRepository.UploadPhoto(photo));
        
        await _bikeRepository.InsertBike(bike);
        return true;
    }
}