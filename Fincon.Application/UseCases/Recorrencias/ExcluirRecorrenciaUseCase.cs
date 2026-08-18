using Fincon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Recorrencias;

public class ExcluirRecorrenciaUseCase
{
    private readonly IRecorrenciaRepository _recorrenciaRepository;
    public ExcluirRecorrenciaUseCase(IRecorrenciaRepository recorrenciaRepository)
        => _recorrenciaRepository = recorrenciaRepository;

    public async Task ExecutarAsync(Guid id)
    {
        await _recorrenciaRepository.ExcluirAsync(id);
    }
}