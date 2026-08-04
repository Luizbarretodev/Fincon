using Fincon.Api.Models;
using Fincon.Application.UseCases.Recorrencias;
using Microsoft.AspNetCore.Mvc;

namespace Fincon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecorrenciasController : ControllerBase
{
    private readonly CriaRecorrenciaUseCase _criaRecorrenciaUseCase;

    public RecorrenciasController(CriaRecorrenciaUseCase criaRecorrenciaUseCase)
    {
        _criaRecorrenciaUseCase = criaRecorrenciaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CriaRecorrenciaRequest request)
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
}