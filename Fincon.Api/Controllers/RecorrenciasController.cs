using Fincon.Api.Models;
using Fincon.Application.UseCases.Recorrencias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecorrenciasController : ControllerBase
{
    private readonly CriarRecorrenciaUseCase _criaRecorrenciaUseCase;
    private readonly AtualizarRecorrenciaUseCase _atualizarRecorrenciaUseCase;
    private readonly ExcluirRecorrenciaUseCase _excluirRecorrenciaUseCase;

    public RecorrenciasController(CriarRecorrenciaUseCase criaRecorrenciaUseCase, AtualizarRecorrenciaUseCase atualizarRecorrenciaUseCase,
                                  ExcluirRecorrenciaUseCase excluirRecorrenciaUseCase)
    {
        _criaRecorrenciaUseCase = criaRecorrenciaUseCase;
        _atualizarRecorrenciaUseCase = atualizarRecorrenciaUseCase;
        _excluirRecorrenciaUseCase = excluirRecorrenciaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CriarRecorrenciaRequest request)
    {
        var recorrencia = await _criaRecorrenciaUseCase.ExecutarAsync(request.Descricao, request.ValorParcela, request.QuantidadeParcelas,
                                                                      request.DataInicio, request.Tipo);

        return Ok(new
        {
            recorrencia.Id,
            recorrencia.Descricao,
            recorrencia.ValorParcela,
            recorrencia.QuantidadeParcelas,
            recorrencia.DataInicio,
            recorrencia.Tipo

        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarRecorrenciaRequest request)
    {
        try
        {
            var recorrencia = await _atualizarRecorrenciaUseCase.ExecutarAsync(id, request.Descricao,
                request.ValorParcela, request.QuantidadeParcelas, request.DataInicio, request.Tipo);
            return Ok(new { recorrencia.Id, recorrencia.Descricao, recorrencia.ValorParcela, recorrencia.QuantidadeParcelas, recorrencia.DataInicio, recorrencia.Tipo });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _excluirRecorrenciaUseCase.ExecutarAsync(id);
        return NoContent();
    }
}