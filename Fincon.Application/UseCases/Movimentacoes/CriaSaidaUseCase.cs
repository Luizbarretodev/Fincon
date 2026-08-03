using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class CriaSaidaUseCase
{
    private readonly ISaidaRepository _saidaRepository;
    private readonly IContaRepository _contaRepository;
    private readonly ICategoriaSaidaRepository _categoriaSaidaRepository;

    public CriaSaidaUseCase(ISaidaRepository saidaRepository, IContaRepository contaRepository, ICategoriaSaidaRepository categoriaSaidaRepository)
    {
        _saidaRepository = saidaRepository;
        _contaRepository = contaRepository;
        _categoriaSaidaRepository = categoriaSaidaRepository;
    }

    public async Task<Saida> ExecutarAsync(DateTime data, decimal valor, string descricao, StatusTransacao status,
                                             Guid contaId, Guid? recorrenciaId, Guid categoriaSaidaId)
    {
        if(!await _contaRepository.ExisteAsync(contaId))
        {
            throw new ArgumentException("Conta informada não encontrada", nameof(contaId));
        }
        if (!await _categoriaSaidaRepository.ExisteAsync(categoriaSaidaId))
        {
            throw new ArgumentException("Categoria informada não encontrada", nameof(categoriaSaidaId));
        }

        var saida = new Saida(data, valor, descricao, status,
                                              contaId, recorrenciaId, categoriaSaidaId);

        await _saidaRepository.AdicionarAsync(saida);
        return saida;
    }
}