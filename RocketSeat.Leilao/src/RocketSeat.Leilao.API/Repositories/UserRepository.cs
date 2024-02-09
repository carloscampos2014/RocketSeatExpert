using Microsoft.EntityFrameworkCore;
using RocketSeat.Leilao.API.Context;
using RocketSeat.Leilao.API.Entities;
using RocketSeat.Leilao.API.Extensions;
using RocketSeat.Leilao.API.Repositories.Contracts;

namespace RocketSeat.Leilao.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LeilaoDbContext _context;

    public UserRepository(LeilaoDbContext context)
    {
        _context = context;
    }

    public async Task<User?> RecuperarUserPeloToken(string token)
    {
        return await _context
            .Users
            .FirstOrDefaultAsync(
                f => f.Email.ToLower() == token.FromBase64().ToLower());
    }
}
