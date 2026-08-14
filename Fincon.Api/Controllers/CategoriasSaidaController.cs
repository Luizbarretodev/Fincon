using Fincon.Api.Models;
using Fincon.Application.UseCases.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasSaidaController : ControllerBase
{
    private readonly CriarCategoriaSaidaUseCase _criaCategoriaSaidaUseCase;
    private readonly ListarCategoriasSaidaUseCase _listaCategoriasSaidaUseCase;
    private readonly AtualizarCategoriaSaidaUseCase _atualizarCategoriaSaidaUseCase;
    private readonly ExcluirCategoriaSaidaUseCase _excluirCategoriaSaidaUseCase;

    public CategoriasSaidaController(CriarCategoriaSaidaUseCase criaSaidaUseCase, ListarCategoriasSaidaUseCase listaCategoriasSaidaUseCase)
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarCategoriaSaidaRequest request)
    {
        try
        {
            var categoriaSaida = await _atualizarCategoriaSaidaUseCase.ExecutarAsync(id, request.Nome);
            return Ok(new { categoriaSaida.Id, categoriaSaida.Nome });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _excluirCategoriaSaidaUseCase.ExecutarAsync(id);
        return NoContent();
    }
}