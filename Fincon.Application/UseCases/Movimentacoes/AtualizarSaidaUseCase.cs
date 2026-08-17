using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class AtualizarSaidaUseCase
{
    private readonly ISaidaRepository _saidaRepository;
    private readonly IContaRepository _contaRepository;
    private readonly ICategoriaSaidaRepository _categoriaSaidaRepository;

    public AtualizarSaidaUseCase(
        ISaidaRepository saidaRepository,
        IContaRepository contaRepository,
        ICategoriaSaidaRepository categoriaSaidaRepository)
    {
        _saidaRepository = saidaRepository;
        _contaRepository = contaRepository;
        _categoriaSaidaRepository = categoriaSaidaRepository;
    }

    public async Task<Saida> ExecutarAsync(Guid id, DateTime data, decimal valor, string descricao,
        StatusTransacao status, Guid contaId, Guid? recorrenciaId, Guid categoriaSaidaId)
    {
        var saida = await _saidaRepository.ObterPorIdAsync(id);
        if (saida == null)
            throw new ArgumentException("Saida não encontrada", nameof(id));

        if (!await _contaRepository.ExisteAsync(contaId))
            throw new ArgumentException("Conta informada não existe", nameof(contaId));

        if (!await _categoriaSaidaRepository.ExisteAsync(categoriaSaidaId))
            throw new ArgumentException("Categoria informada não existe", nameof(categoriaSaidaId));

        saida.Atualizar(data, valor, descricao, status, contaId, recorrenciaId, categoriaSaidaId);
        await _saidaRepository.AtualizarAsync(saida);
        return saida;
    }
}
