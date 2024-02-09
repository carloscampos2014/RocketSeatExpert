using RocketSeat.Leilao.API.Entities;

namespace RocketSeat.Leilao.API.Repositories.Contracts;

public interface IOfertaRepository
{
    Task<Offer> Adicionar(Offer model);
}
