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

    public ContasController(CriarContaUseCase criaContaUseCase, ListarContasUseCase listarContasUseCase)
    {
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
}