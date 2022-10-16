using BikeShop.Models;
using MediatR;

namespace BikeShop.Queries;

public class GetBikeByIdQuery : IRequest<BikeViewModel>
{
    public GetBikeByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}