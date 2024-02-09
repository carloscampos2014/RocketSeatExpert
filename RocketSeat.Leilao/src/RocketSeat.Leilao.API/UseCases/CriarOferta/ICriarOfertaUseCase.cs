using RocketSeat.Leilao.API.Communication.Request;
using RocketSeat.Leilao.API.Entities;

namespace RocketSeat.Leilao.API.UseCases.CriarOferta;

public interface ICriarOfertaUseCase
{
    Task<Offer> Execute(int itemId, RequestCriarOfertaJson request);
}
