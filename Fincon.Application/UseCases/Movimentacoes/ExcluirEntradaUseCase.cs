using Fincon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class ExcluirEntradaUseCase
{
    private readonly IEntradaRepository _entradaRepository;
    public ExcluirEntradaUseCase(IEntradaRepository entradaRepository) => _entradaRepository = entradaRepository;

    public async Task ExecutarAsync(Guid id)
    {
        await _entradaRepository.ExcluirAsync(id);
    }
}