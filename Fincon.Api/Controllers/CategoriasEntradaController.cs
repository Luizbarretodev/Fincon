using Fincon.Api.Models;
using Fincon.Application.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasEntradaController : ControllerBase
{
    private readonly CriarCategoriaEntradaUseCase _criaCategoriaEntradaUseCase;
    private readonly ListarCategoriasEntradaUseCase _listaCategoriasEntradaUseCase;
    private readonly AtualizarCategoriaEntradaUseCase _atualizarCategoriaEntradaUseCase;
    private readonly ExcluirCategoriaEntradaUseCase _excluirCategoriaEntradaUseCase;

    public CategoriasEntradaController(CriarCategoriaEntradaUseCase criaEntradaUseCase, ListarCategoriasEntradaUseCase listaCategoriasEntradaUseCase,
        AtualizarCategoriaEntradaUseCase atualizarCategoriaEntradaUseCase, ExcluirCategoriaEntradaUseCase excluirCategoriaEntradaUseCase)
    {
        _criaCategoriaEntradaUseCase = criaEntradaUseCase;
        _listaCategoriasEntradaUseCase = listaCategoriasEntradaUseCase;
        _atualizarCategoriaEntradaUseCase = atualizarCategoriaEntradaUseCase;
        _excluirCategoriaEntradaUseCase = excluirCategoriaEntradaUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categoriasEntrada = await _listaCategoriasEntradaUseCase.ExecutarAsync();

        return Ok(categoriasEntrada.Select(ce => new { ce.Id, ce.Nome }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriaCategoriaEntradaRequest request)
    {
        var entrada = await _criaCategoriaEntradaUseCase.ExecutarAsync(request.Nome);

        return Ok(new { entrada.Id, entrada.Nome });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarCategoriaEntradaRequest request)
    {
        try
        {
            var categoriaEntrada = await _atualizarCategoriaEntradaUseCase.ExecutarAsync(id, request.Nome);
            return Ok(new { categoriaEntrada.Id, categoriaEntrada.Nome });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _excluirCategoriaEntradaUseCase.ExecutarAsync(id);
        return NoContent();
    }
}