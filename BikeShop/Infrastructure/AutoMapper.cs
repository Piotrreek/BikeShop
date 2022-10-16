using AutoMapper;
using BikeShop.Entities;
using BikeShop.Models;

namespace BikeShop.Infrastructure;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<UserViewModel, User>();
        CreateMap<CreateBikeViewModel, Bike>();
        CreateMap<Bike, BikeViewModel>();
    }
}