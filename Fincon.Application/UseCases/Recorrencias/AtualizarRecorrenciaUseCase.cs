using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Recorrencias;

public class AtualizarRecorrenciaUseCase
{
    private readonly IRecorrenciaRepository _recorrenciaRepository;
    public AtualizarRecorrenciaUseCase(IRecorrenciaRepository recorrenciaRepository)
    {
        _recorrenciaRepository = recorrenciaRepository;
    }

    public async Task<Recorrencia> ExecutarAsync(Guid id, string descricao, decimal valorParcela, int quantidadeParcelas, DateTime dataInicio, TipoRecorrencia tipo)
    {
        var recorrencia = await _recorrenciaRepository.ObterPorIdAsync(id);
        if (recorrencia == null)
            throw new ArgumentException("Recorrência não encontrada", nameof(id));

        recorrencia.Atualizar(descricao, valorParcela, quantidadeParcelas, dataInicio, tipo);
        await _recorrenciaRepository.AtualizarAsync(recorrencia);
        return recorrencia;
    }
}