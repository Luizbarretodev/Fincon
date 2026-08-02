using Fincon.Api.Models;
using Fincon.Application.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasSaidaController : ControllerBase
{
    private readonly CriaSaidaUseCase _criaSaidaUseCase;

    public CategoriasSaidaController(CriaSaidaUseCase criaSaidaUseCase)
    {
        _criaSaidaUseCase = criaSaidaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaCategoriaSaidaRequest request)
    {
        var saida = await _criaSaidaUseCase.ExecutarAsync(request.Nome);

        return Ok(new { saida.Id, saida.Nome });
    }
}