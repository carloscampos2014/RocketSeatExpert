namespace RocketSeat.Leilao.API.UseCases.PegarAtual;

public interface IPegarAtualLeilaoUseCase
{
    Task<Entities.Auction?> Executar();
}
