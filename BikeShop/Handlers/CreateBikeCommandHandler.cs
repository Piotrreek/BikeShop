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
    private readonly IValidationService<CreateBikeViewModel> _validator;
    private readonly IMapper _mapper;

    public CreateBikeCommandHandler(IBikeRepository bikeRepository, IValidationService<CreateBikeViewModel> validator, IMapper mapper)
    {
        _bikeRepository = bikeRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Model, request.ModelState);
        if (validationResult == ValidationResult.Fail)
            return false;

        var bike = _mapper.Map<Bike>(request.Model);
        // teraz logika zeby dodac zdjecia i reszte propertasow
        
        return true;
    }
}