using Fincon.Application.Interfaces;
using Fincon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class ListarEntradasUseCase
{
    private readonly IEntradaRepository _entradaRepository;

    public ListarEntradasUseCase(IEntradaRepository entradaRepository)
    {
        _entradaRepository = entradaRepository;
    }

    public async Task<List<Entrada>> ExecutarAsync()
    {
        return await _entradaRepository.ListarAsync();
    }
}