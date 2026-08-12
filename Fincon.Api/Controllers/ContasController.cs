using Fincon.Api.Models;
using Fincon.Application.UseCases.Contas;
using Fincon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
    private readonly CriarContaUseCase _criaContaUseCase;
    private readonly ListarContasUseCase _listarContasUseCase;
    private readonly AtualizarContaUseCase _atualizarContaUseCase;
    private readonly ExcluirContaUseCase _excluirContaUseCase;

    public ContasController(AtualizarContaUseCase atualizarContaUseCase, ExcluirContaUseCase excluirContaUseCase,
                            CriarContaUseCase criaContaUseCase, ListarContasUseCase listarContasUseCase)
    {
        _atualizarContaUseCase = atualizarContaUseCase;
        _excluirContaUseCase = excluirContaUseCase;
        _criaContaUseCase = criaContaUseCase;
        _listarContasUseCase = listarContasUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var contas = await _listarContasUseCase.ExecutarAsync();
        return Ok(contas.Select(c => new { c.Id, c.Nome }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaContaRequest request)
    {
        var conta = await _criaContaUseCase.ExecutarAsync(request.Nome);

        return Ok(new { conta.Id, conta.Nome });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarContaRequest request)
    {
        try
        {
            var conta = await _atualizarContaUseCase.ExecutarAsync(id, request.nome);
            return Ok(new { conta.Id, conta.Nome });
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _excluirContaUseCase.ExecutarAsync(id);
        return NoContent();
    }
}