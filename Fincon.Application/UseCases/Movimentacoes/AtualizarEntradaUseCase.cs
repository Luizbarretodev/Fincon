using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class AtualizarEntradaUseCase
{
    private readonly IEntradaRepository _entradaRepository;
    private readonly IContaRepository _contaRepository;
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;

    public AtualizarEntradaUseCase(
        IEntradaRepository entradaRepository,
        IContaRepository contaRepository,
        ICategoriaEntradaRepository categoriaEntradaRepository)
    {
        _entradaRepository = entradaRepository;
        _contaRepository = contaRepository;
        _categoriaEntradaRepository = categoriaEntradaRepository;
    }

    public async Task<Entrada> ExecutarAsync(Guid id, DateTime data, decimal valor, string descricao,
        StatusTransacao status, Guid contaId, Guid? recorrenciaId, Guid categoriaEntradaId)
    {
        var entrada = await _entradaRepository.ObterPorIdAsync(id);
        if (entrada == null)
            throw new ArgumentException("Entrada não encontrada", nameof(id));

        if (!await _contaRepository.ExisteAsync(contaId))
            throw new ArgumentException("Conta informada não existe", nameof(contaId));

        if (!await _categoriaEntradaRepository.ExisteAsync(categoriaEntradaId))
            throw new ArgumentException("Categoria informada não existe", nameof(categoriaEntradaId));

        entrada.Atualizar(data, valor, descricao, status, contaId, recorrenciaId, categoriaEntradaId);
        await _entradaRepository.AtualizarAsync(entrada);
        return entrada;
    }
}