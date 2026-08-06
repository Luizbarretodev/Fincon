using Fincon.Api.Models;
using Fincon.Application.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasSaidaController : ControllerBase
{
    private readonly CriaCategoriaSaidaUseCase _criaCategoriaSaidaUseCase;
    private readonly ListaCategoriasSaidaUseCase _listaCategoriasSaidaUseCase;

    public CategoriasSaidaController(CriaCategoriaSaidaUseCase criaSaidaUseCase, ListaCategoriasSaidaUseCase listaCategoriasSaidaUseCase)
    {
        _criaCategoriaSaidaUseCase = criaSaidaUseCase;
        _listaCategoriasSaidaUseCase = listaCategoriasSaidaUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categoriasSaidas = await _listaCategoriasSaidaUseCase.ExecutarAsync();

        return Ok(categoriasSaidas.Select(cs => new { cs.Id, cs.Nome}));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaCategoriaSaidaRequest request)
    {
        var saida = await _criaCategoriaSaidaUseCase.ExecutarAsync(request.Nome);

        return Ok(new { saida.Id, saida.Nome });
    }
}