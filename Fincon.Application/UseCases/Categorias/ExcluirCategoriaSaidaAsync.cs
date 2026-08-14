using Fincon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fincon.Application.UseCases.Categorias;

public class ExcluirCategoriaSaidaUseCase
{
    private readonly ICategoriaSaidaRepository _categoriaSaidaRepository;
    public ExcluirCategoriaSaidaUseCase(ICategoriaSaidaRepository categoriaSaidaRepository)
    {
        _categoriaSaidaRepository = categoriaSaidaRepository;
    }

    public async Task ExecutarAsync(Guid id)
    {
        await _categoriaSaidaRepository.ExcluirAsync(id);
    }
}