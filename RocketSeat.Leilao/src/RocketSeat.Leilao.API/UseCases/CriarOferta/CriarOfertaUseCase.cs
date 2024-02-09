using RocketSeat.Leilao.API.Communication.Request;
using RocketSeat.Leilao.API.Entities;
using RocketSeat.Leilao.API.Repositories.Contracts;

namespace RocketSeat.Leilao.API.UseCases.CriarOferta;

public class CriarOfertaUseCase : ICriarOfertaUseCase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IOfertaRepository _ofertaRepository;

    public CriarOfertaUseCase(IHttpContextAccessor httpContextAccessor, IOfertaRepository ofertaRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _ofertaRepository = ofertaRepository;
    }

    public async Task<Offer> Execute(int itemId, RequestCriarOfertaJson request)
    {
        _ = int.TryParse(_httpContextAccessor.HttpContext.Response.Headers["userId"], out int userId);

        var oferta = new Offer
        {
            CreatedOn = DateTime.Now.ToString(),
            ItemId = itemId,
            UserId = userId,
            Price = request.Price,
        };

        return await _ofertaRepository.Adicionar(oferta);
    }
}
