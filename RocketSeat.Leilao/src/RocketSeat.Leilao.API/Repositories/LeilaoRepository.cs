using Microsoft.EntityFrameworkCore;
using RocketSeat.Leilao.API.Context;
using RocketSeat.Leilao.API.Repositories.Contracts;

namespace RocketSeat.Leilao.API.Repositories;

public class LeilaoRepository : ILeilaoRepository
{
    private readonly LeilaoDbContext _context;

    public LeilaoRepository(LeilaoDbContext context)
    {
        _context = context;
    }

    public async Task<Entities.Auction> Adicionar(Entities.Auction model)
    {
        _context.Auctions.Add(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Entities.Auction> Atualizar(Entities.Auction model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task Apagar(Entities.Auction model)
    {
        _context.Auctions.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.Auction?> PegarLeilaoAtual()
    {
        var today = DateTime.Now;
        return await _context.Auctions
            .Include(x => x.Items)
            .FirstOrDefaultAsync(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
