using RocketSeat.Leilao.API.Repositories;
using RocketSeat.Leilao.API.Repositories.Contracts;

namespace RocketSeat.Leilao.API.UseCases.PegarAtual;

public class PegarAtualLeilaoUseCase : IPegarAtualLeilaoUseCase
{
    private readonly ILeilaoRepository _leilaoRepository;

    public PegarAtualLeilaoUseCase(ILeilaoRepository leilaoRepository)
    {
        _leilaoRepository = leilaoRepository;
    }

    public async Task<Entities.Auction?> Executar()
    {
        return await _leilaoRepository.PegarLeilaoAtual();
    }
}
