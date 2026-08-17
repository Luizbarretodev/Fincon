using Fincon.Api.Models;
using Fincon.Application.UseCases.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaidasController : ControllerBase
{
    private readonly CriarSaidaUseCase _criaSaidaUseCase;
    private readonly AtualizarSaidaUseCase _atualizarSaidaUseCase;
    private readonly ExcluirSaidaUseCase _excluirSaidaUseCase;

    public SaidasController(CriarSaidaUseCase criaSaidaUseCase, AtualizarSaidaUseCase atualizarSaidaUseCase, 
                            ExcluirSaidaUseCase excluirSaidaUseCase)
    {
        _criaSaidaUseCase = criaSaidaUseCase;
        _atualizarSaidaUseCase = atualizarSaidaUseCase;
        _excluirSaidaUseCase = excluirSaidaUseCase;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarSaidaRequest request)
    {
        try
        {
            var saida = await _atualizarSaidaUseCase.ExecutarAsync(id, request.Data, request.Valor,
                request.Descricao, request.Status, request.ContaId, request.RecorrenciaId, request.CategoriaSaidaId);
            return Ok(new { saida.Id, saida.Data, saida.Valor, saida.Descricao, saida.Status, saida.ContaId, saida.CategoriaSaidaId });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _excluirSaidaUseCase.ExecutarAsync(id);
        return NoContent();
    }
}
