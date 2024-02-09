namespace RocketSeat.Leilao.API.Repositories.Contracts;

public interface ILeilaoRepository
{
    Task<Entities.Auction> Adicionar(Entities.Auction model);

    Task<Entities.Auction> Atualizar(Entities.Auction model);

    Task Apagar(Entities.Auction model);

    Task<Entities.Auction?> PegarLeilaoAtual();
}
