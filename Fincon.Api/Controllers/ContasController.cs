using Fincon.Api.Models;
using Fincon.Application.UseCases.Contas;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContasController : ControllerBase
{
    private readonly CriaContaUseCase _criaContaUseCase;

    public ContasController(CriaContaUseCase criaContaUseCase)
    {
        _criaContaUseCase = criaContaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarContaRequest request)
    {
        var conta = await _criaContaUseCase.ExecutarAsync(request.Nome);

        return Ok(new { conta.Id, conta.Nome }); 
    }
}