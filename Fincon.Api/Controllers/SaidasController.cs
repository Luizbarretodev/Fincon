using Fincon.Api.Models;
using Fincon.Application.UseCases.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaidasController : ControllerBase
{
    private readonly CriarSaidaUseCase _criaSaidaUseCase;

    public SaidasController(CriarSaidaUseCase criaSaidaUseCase)
    {
        _criaSaidaUseCase = criaSaidaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaSaidaRequest request)
    {
        var saida = await _criaSaidaUseCase.ExecutarAsync(request.Data, request.Valor, request.Descricao, request.Status,
                                                              request.ContaId, request.RecorrenciaId, request.CategoriaSaidaId);

        return Ok(new
        {
            saida.Id,
            saida.Data,
            saida.Valor,
            saida.Descricao,
            saida.Status,
            saida.ContaId,
            saida.CategoriaSaidaId
        });
    }
}
