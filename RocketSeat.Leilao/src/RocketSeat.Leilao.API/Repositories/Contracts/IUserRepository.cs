using RocketSeat.Leilao.API.Entities;

namespace RocketSeat.Leilao.API.Repositories.Contracts;

public interface IUserRepository
{
    Task<User?> RecuperarUserPeloToken(string token);
}
