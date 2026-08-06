using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using Fincon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class CriarEntradaUseCase
{
    private readonly IEntradaRepository _entradaRepository;
    private readonly IContaRepository _contaRepository;
    private readonly ICategoriaEntradaRepository _categoriaEntradaRepository;

    public CriarEntradaUseCase(IEntradaRepository entradaRepository, IContaRepository contaRepository, ICategoriaEntradaRepository categoriaEntradaRepository)
    {
        _entradaRepository = entradaRepository;
        _contaRepository = contaRepository;
        _categoriaEntradaRepository = categoriaEntradaRepository;
    }

    public async Task<Entrada> ExecutarAsync(DateTime data, decimal valor, string descricao, StatusTransacao status, 
                                             Guid contaId, Guid? recorrenciaId, Guid categoriaEntradaId)
    {
        if (! await _contaRepository.ExisteAsync(contaId))
        {
            throw new ArgumentException("Conta informada não existe", nameof(contaId));
        }
        if (!await _categoriaEntradaRepository.ExisteAsync(categoriaEntradaId))
        {
            throw new ArgumentException("Categoria informada não existe", nameof(categoriaEntradaId));
        }

        var entrada = new Entrada(data, valor, descricao, status,
                                              contaId, recorrenciaId, categoriaEntradaId);

        await _entradaRepository.AdicionarAsync(entrada);
        return entrada;
    }
}