using Fincon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Contas;

public class ExcluirContaUseCase
{
    private readonly IContaRepository _contaRepository;

    public ExcluirContaUseCase(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task ExecutarAsync(Guid id)
    {
        await _contaRepository.ExcluirAsync(id);
    }
}