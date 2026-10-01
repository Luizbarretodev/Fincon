using Fincon.Api.Models.Movimentacoes;
using Fincon.Application.UseCases.Movimentacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EntradasController : ControllerBase
{
    private readonly CriarEntradaUseCase _criaEntradaUseCase;
    private readonly AtualizarEntradaUseCase _atualizarEntradaUseCase;
    private readonly ExcluirEntradaUseCase _excluirEntradaUseCase;

    public EntradasController(CriarEntradaUseCase criaEntradaUseCase, AtualizarEntradaUseCase atualizarEntradaUseCase,
        ExcluirEntradaUseCase excluirEntradaUseCase)
    {
        _criaEntradaUseCase = criaEntradaUseCase;
        _atualizarEntradaUseCase = atualizarEntradaUseCase;
        _excluirEntradaUseCase = excluirEntradaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaEntradaRequest request)
    {
        var entrada = await _criaEntradaUseCase.ExecutarAsync(request.Data, request.Valor, request.Descricao, request.Status,
                                                              request.ContaId, request.RecorrenciaId, request.CategoriaEntradaId);

        return Ok(new
        {
            entrada.Id,
            entrada.Data,
            entrada.Valor,
            entrada.Descricao,
            entrada.Status,
            entrada.ContaId,
            entrada.CategoriaEntradaId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarEntradaRequest request)
    {
        try
        {
            try
            {
                var entrada = await _atualizarEntradaUseCase.ExecutarAsync(id, request.Data, request.Valor,
                    request.Descricao, request.Status, request.ContaId, request.RecorrenciaId, request.CategoriaSaidaId);
                return Ok(new { entrada.Id, entrada.Data, entrada.Valor, entrada.Descricao, entrada.Status, entrada.ContaId, entrada.CategoriaEntradaId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}