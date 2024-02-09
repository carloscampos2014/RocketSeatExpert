using RocketSeat.Leilao.API.Context;
using RocketSeat.Leilao.API.Entities;
using RocketSeat.Leilao.API.Repositories.Contracts;

namespace RocketSeat.Leilao.API.Repositories;

public class OfertaRepository : IOfertaRepository
{
    private readonly LeilaoDbContext _context;

    public OfertaRepository(LeilaoDbContext context)
    {
        _context = context;
    }

    public async Task<Offer> Adicionar(Offer model)
    {
        _context.Offers.Add(model);
        await _context.SaveChangesAsync();
        return model;
    }
}
