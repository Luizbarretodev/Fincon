using Fincon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Movimentacoes;

public class ExcluirSaidaUseCase
{
    private readonly ISaidaRepository _saidaRepository;
    public ExcluirSaidaUseCase(ISaidaRepository saidaRepository) => _saidaRepository = saidaRepository;

    public async Task ExecutarAsync(Guid id)
    {
        await _saidaRepository.ExcluirAsync(id);
    }
}