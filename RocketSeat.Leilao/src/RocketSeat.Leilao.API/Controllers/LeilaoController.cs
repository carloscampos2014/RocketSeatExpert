using Microsoft.AspNetCore.Mvc;
using RocketSeat.Leilao.API.Entities;
using RocketSeat.Leilao.API.UseCases.PegarAtual;

namespace RocketSeat.Leilao.API.Controllers;

public class LeilaoController : LeilaoApiBaseController
{
    private readonly IPegarAtualLeilaoUseCase _pegarAtualLeilaoUseCase;

    public LeilaoController(IPegarAtualLeilaoUseCase pegarAtualLeilaoUseCase)
    {
        _pegarAtualLeilaoUseCase = pegarAtualLeilaoUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PegarLeilaoAtual()
    {
        try
        {
            var leilao = _pegarAtualLeilaoUseCase.Executar().Result;

            if (leilao is null)
            {
                return NoContent();
            }

            return Ok(leilao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
