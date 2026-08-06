using Fincon.Api.Models;
using Fincon.Application.UseCases.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntradasController : ControllerBase
{
    private readonly CriarEntradaUseCase _criaEntradaUseCase;

    public EntradasController(CriarEntradaUseCase criaEntradaUseCase)
    {
        _criaEntradaUseCase = criaEntradaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaEntradaRequest request)
    {
        var entrada = await _criaEntradaUseCase.ExecutarAsync(request.Data, request.Valor, request.Descricao, request.Status,
                                                              request.ContaId, request.RecorrenciaId, request.CategoriaEntradaId);

        return Ok(new { entrada.Id, entrada.Data, entrada.Valor, entrada.Descricao,
                        entrada.Status, entrada.ContaId, entrada.CategoriaEntradaId });
    }
}