using Microsoft.AspNetCore.Mvc;
using RocketSeat.Leilao.API.Communication.Request;
using RocketSeat.Leilao.API.Filtros;
using RocketSeat.Leilao.API.UseCases.CriarOferta;

namespace RocketSeat.Leilao.API.Controllers;

public class OfertaController : LeilaoApiBaseController
{
    private readonly ICriarOfertaUseCase _criarOfertaUseCase;

    public OfertaController(ICriarOfertaUseCase criarOfertaUseCase)
    {
        _criarOfertaUseCase = criarOfertaUseCase;
    }

    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CriarOferta([FromRoute] int itemId, [FromBody] RequestCriarOfertaJson request)
    {
        try
        {
            var oferta = _criarOfertaUseCase.Execute(itemId, request).Result;
            return Created("oferta", oferta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
