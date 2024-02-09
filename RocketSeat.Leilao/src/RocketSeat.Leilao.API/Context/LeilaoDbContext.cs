using Microsoft.EntityFrameworkCore;

namespace RocketSeat.Leilao.API.Context;

public class LeilaoDbContext : DbContext
{
    public LeilaoDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Entities.Auction> Auctions { get; set; }

    public DbSet<Entities.Item> Items { get; set; }

    public DbSet<Entities.Offer> Offers { get; set; }

    public DbSet<Entities.User> Users { get; set; }
}
