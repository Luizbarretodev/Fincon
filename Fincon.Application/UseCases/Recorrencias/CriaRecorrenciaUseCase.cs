using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Recorrencias;

public class CriaRecorrenciaUseCase
{
    private readonly IRecorrenciaRepository _recorrenciaRepository;

    public CriaRecorrenciaUseCase(IRecorrenciaRepository recorrenciaRepository)
    {
        _recorrenciaRepository = recorrenciaRepository;
    }

    public async Task<Recorrencia> ExecutarAsync(string descricao, decimal valorParcela, int quantidadeParcelas, 
                                                 DateTime dataInicio, TipoRecorrencia tipo)
    {
        var recorrencia = new Recorrencia(descricao, valorParcela, quantidadeParcelas, dataInicio, tipo);

        await _recorrenciaRepository.AdicionarAsync(recorrencia);
        return recorrencia;
    }
}