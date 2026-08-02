using Fincon.Api.Models;
using Fincon.Application.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasEntradaController : ControllerBase
{
    private readonly CriaEntradaUseCase _criaEntradaUseCase;

    public CategoriasEntradaController(CriaEntradaUseCase criaEntradaUseCase)
    {
        _criaEntradaUseCase = criaEntradaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaCategoriaEntradaRequest request)
    {
        var entrada = await _criaEntradaUseCase.ExecutarAsync(request.Nome);

        return Ok(new { entrada.Id, entrada.Nome });
    }
}
